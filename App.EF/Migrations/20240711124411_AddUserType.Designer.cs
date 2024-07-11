﻿// <auto-generated />
using System;
using App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240711124411_AddUserType")]
    partial class AddUserType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.CategoryModule.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"));

                    b.Property<string>("categoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.ColorModule.Color", b =>
                {
                    b.Property<int>("colorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("colorId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("colorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colorHexCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("colorId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.LogActionsModel.LogAction", b =>
                {
                    b.Property<int>("logActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("logActionId"));

                    b.Property<DateTimeOffset>("actionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("actionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("newData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oldData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("logActionId");

                    b.ToTable("LogActions");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.UnitModule.Unit", b =>
                {
                    b.Property<int>("unitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("unitId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("unitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitSympol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("unitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("App.Shared.Models.Branches.Branch", b =>
                {
                    b.Property<int>("branchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("branchId"));

                    b.Property<TimeSpan>("branchCloseAt")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("branchOpenAt")
                        .HasColumnType("time");

                    b.HasKey("branchId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("App.Shared.Models.Buyers.Buyer", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly>("buyerBirthDate")
                        .HasColumnType("date");

                    b.Property<string>("buyerCountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerCountryCodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerDailCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("buyerIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("buyerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buyerPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("userId");

                    b.ToTable("Buyer");
                });

            modelBuilder.Entity("App.Shared.Models.ProductStores.ProductStore", b =>
                {
                    b.Property<int>("productStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productStoreId"));

                    b.Property<int>("colorId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("unitId")
                        .HasColumnType("int");

                    b.HasKey("productStoreId");

                    b.HasIndex("colorId");

                    b.HasIndex("productId");

                    b.HasIndex("unitId");

                    b.ToTable("ProductStores");
                });

            modelBuilder.Entity("App.Shared.Models.Products.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"));

                    b.Property<int?>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Shared.Models.Roles.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("roleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("App.Shared.Models.Stores.Store", b =>
                {
                    b.Property<int>("storeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("storeId"));

                    b.Property<TimeSpan>("storeCloseAt")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("storeOpenAt")
                        .HasColumnType("time");

                    b.HasKey("storeId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("App.Shared.Models.Users.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Shared.Models.Branches.Branch", b =>
                {
                    b.OwnsOne("App.Shared.Models.Branches.BranchContactInfo", "branchContactInfo", b1 =>
                        {
                            b1.Property<int>("branchId")
                                .HasColumnType("int");

                            b1.Property<string>("branchAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchCountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchCountryCodeName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchDailCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchEmail")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("branchLatitude")
                                .HasColumnType("float");

                            b1.Property<double>("branchLongitude")
                                .HasColumnType("float");

                            b1.Property<string>("branchManagerName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("branchPhoneNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("jsutForBuildEF")
                                .HasColumnType("bit");

                            b1.HasKey("branchId");

                            b1.ToTable("Branches");

                            b1.WithOwner()
                                .HasForeignKey("branchId");
                        });

                    b.OwnsOne("App.Shared.Models.Branches.BranchContactSocialMedia", "branchContactSocialMedia", b1 =>
                        {
                            b1.Property<int>("branchId")
                                .HasColumnType("int");

                            b1.Property<string>("branchWebsite")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("facebookLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("instagramLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("jsutForBuildEF")
                                .HasColumnType("bit");

                            b1.Property<string>("linkedinLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("twitterLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("youtubeLink")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("branchId");

                            b1.ToTable("Branches");

                            b1.WithOwner()
                                .HasForeignKey("branchId");
                        });

                    b.Navigation("branchContactInfo");

                    b.Navigation("branchContactSocialMedia");
                });

            modelBuilder.Entity("App.Shared.Models.Buyers.Buyer", b =>
                {
                    b.HasOne("App.Shared.Models.Users.User", "user")
                        .WithOne("userBuyerData")
                        .HasForeignKey("App.Shared.Models.Buyers.Buyer", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("App.Shared.Models.ProductStores.ProductStore", b =>
                {
                    b.HasOne("App.Shared.Models.AdditionsModules.ColorModule.Color", "colorData")
                        .WithMany("productStoreData")
                        .HasForeignKey("colorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Shared.Models.Products.Product", "productData")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Shared.Models.AdditionsModules.UnitModule.Unit", "unitData")
                        .WithMany("productStoresData")
                        .HasForeignKey("unitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("colorData");

                    b.Navigation("productData");

                    b.Navigation("unitData");
                });

            modelBuilder.Entity("App.Shared.Models.Products.Product", b =>
                {
                    b.HasOne("App.Shared.Models.AdditionsModules.CategoryModule.Category", null)
                        .WithMany("productsData")
                        .HasForeignKey("categoryId");
                });

            modelBuilder.Entity("App.Shared.Models.Stores.Store", b =>
                {
                    b.OwnsOne("App.Shared.Models.Stores.StoreContactInfo", "storeContactInfo", b1 =>
                        {
                            b1.Property<int>("storeId")
                                .HasColumnType("int");

                            b1.Property<bool>("jsutForBuildEF")
                                .HasColumnType("bit");

                            b1.Property<string>("storeAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeCountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeCountryCodeName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeDailCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeEmail")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("storeLatitude")
                                .HasColumnType("float");

                            b1.Property<double>("storeLongitude")
                                .HasColumnType("float");

                            b1.Property<string>("storeManagerName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storePhoneNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("storeId");

                            b1.ToTable("Stores");

                            b1.WithOwner()
                                .HasForeignKey("storeId");
                        });

                    b.OwnsOne("App.Shared.Models.Stores.StoreContactSocialMedia", "storeContactSocialMedia", b1 =>
                        {
                            b1.Property<int>("storeId")
                                .HasColumnType("int");

                            b1.Property<string>("facebookLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("instagramLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("jsutForBuildEF")
                                .HasColumnType("bit");

                            b1.Property<string>("linkedinLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("storeWebsite")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("twitterLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("youtubeLink")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("storeId");

                            b1.ToTable("Stores");

                            b1.WithOwner()
                                .HasForeignKey("storeId");
                        });

                    b.Navigation("storeContactInfo");

                    b.Navigation("storeContactSocialMedia");
                });

            modelBuilder.Entity("App.Shared.Models.Users.User", b =>
                {
                    b.HasOne("App.Shared.Models.Roles.Role", "roleData")
                        .WithMany("usersData")
                        .HasForeignKey("roleId");

                    b.Navigation("roleData");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.CategoryModule.Category", b =>
                {
                    b.Navigation("productsData");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.ColorModule.Color", b =>
                {
                    b.Navigation("productStoreData");
                });

            modelBuilder.Entity("App.Shared.Models.AdditionsModules.UnitModule.Unit", b =>
                {
                    b.Navigation("productStoresData");
                });

            modelBuilder.Entity("App.Shared.Models.Roles.Role", b =>
                {
                    b.Navigation("usersData");
                });

            modelBuilder.Entity("App.Shared.Models.Users.User", b =>
                {
                    b.Navigation("userBuyerData");
                });
#pragma warning restore 612, 618
        }
    }
}
