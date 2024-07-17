using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Shared;
using App.Shared.Consts.Users;
using App.Shared.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.ViewModel;
using App.Shared.Models.SystemBase.Roles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Controllers.SystemBase.SystemRoleFincations
{
    internal class SystemRoleFincationService : ISystemRoleFincationsService
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemRoleFincationsClientService _systemRoleFincationsClientService;
        private readonly ISystemRoleFincationsMangerService _systemRoleFincationsMangerService;

        #endregion Members

        #region Constructor

        public SystemRoleFincationService(IUnitOfWork unitOfWork, IMapper mapper, ISystemRoleFincationsClientService systemRoleFincationsClientService, ISystemRoleFincationsMangerService systemRoleFincationsMangerService)

        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _systemRoleFincationsClientService = systemRoleFincationsClientService;
            _systemRoleFincationsMangerService = systemRoleFincationsMangerService;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<SystemRoleFunctionInfo>> GetDetails(int systemRoleId)
        {
            // Fetch the system role based on the given ID
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleId == systemRoleId);

            // Fetch the system role functions for the given role ID from the database
            var systemRoleFincationsInDB = await _unitOfWork.SystemRoleFincations
                .AsQueryable()
                .Where(x => x.systemRoleId == systemRoleId)
                .ToListAsync() ?? new List<SystemRoleFincation>();

            // Get the detailed system role functions
            var systemRoleFunctions = GetSystemRoleFincations(systemRole, systemRoleFincationsInDB);

            return GetSystemRoleFunctionsGroupedByModuleId(systemRoleFunctions);
        }

        public async Task<BaseActionDone<List<SystemRoleFincation>>> UpdatePrivilege(SystemRoleFincationDto inputModel)
        {
            // Delete existing functions for the given system role ID
            _unitOfWork.SystemRoleFincations
                .AsQueryable()
                .Where(x => x.systemRoleId == inputModel.systemRoleId)
                .ExecuteDelete();

            // Commit the changes
            await _unitOfWork.CommitAsync();

            // Fetch the system role based on the input model's role ID
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleId == inputModel.systemRoleId);

            // Get the detailed system role functions based on the input model
            List<SystemRoleFincation> systemRoleFincations = GetSystemRoleFincations(systemRole, inputModel.systemRoleFincations.ToList());

            // Filter the functions that have privileges
            systemRoleFincations = systemRoleFincations.Where(x => x.isHavePrivlage).ToList();

            if (systemRoleFincations.Count > 0)
            {
                // Add new functions with privileges
                await _unitOfWork.SystemRoleFincations.AddRangeAsync(systemRoleFincations);

                // Commit the changes
                var isDone = await _unitOfWork.CommitAsync();

                // Return success with the updated functions
                return BaseActionDone<List<SystemRoleFincation>>.GenrateBaseActionDone(isDone, systemRoleFincations);
            }
            else
            {
                // Return success with no functions if none have privileges
                return BaseActionDone<List<SystemRoleFincation>>.GenrateBaseActionDone(1, systemRoleFincations);
            }
        }

        private List<SystemRoleFincation> GetSystemRoleFincations(SystemRole systemRole, List<SystemRoleFincation> inputSystemRoleFincations)
        {
            List<SystemRoleFincation> trueSystemRoleFincation = new List<SystemRoleFincation>();

            // Determine the user type and fetch the corresponding functions
            if (systemRole.systemRoleUserType == EnumUserType.Manger)
                trueSystemRoleFincation = _systemRoleFincationsMangerService.GetSystemRoleFincations();
            else if (systemRole.systemRoleUserType == EnumUserType.Client)
                trueSystemRoleFincation = _systemRoleFincationsClientService.GetSystemRoleFincations();

            // Migrate input functions and trueSystemRoleFincation, updating privileges
            trueSystemRoleFincation.ForEach(z =>
            {
                z.systemRoleId = systemRole.systemRoleId;
                z.isHavePrivlage = inputSystemRoleFincations.FirstOrDefault(x => x.funcationId == z.funcationId, new SystemRoleFincation()).isHavePrivlage;
            });



            return trueSystemRoleFincation;
        }
        
        private List<SystemRoleFunctionInfo> GetSystemRoleFunctionsGroupedByModuleId(List<SystemRoleFincation> systemRoleFincations)
        {
            var trueSystemRoleFincationsGroupedByModuleId = systemRoleFincations.GroupBy(x => x.moduleId);


            List<SystemRoleFunctionInfo> systemRoleFincationsInfo = new();


            foreach (var item in trueSystemRoleFincationsGroupedByModuleId)
            {
                systemRoleFincationsInfo.Add(
                    new SystemRoleFunctionInfo
                    {
                        systemRoleFunctionModule = item.Key,
                        systemRoleFunctions = item.ToList()
                    }
                    );
            }

            return systemRoleFincationsInfo;
        }



        #endregion Methods
    }
}