﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moc_DynamicCustomerService.Data;

#nullable disable

namespace Moc_DynamicCustomerService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Accounts", b =>
                {
                    b.Property<int>("Account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MainEmail")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPhone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Account_id");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Cases", b =>
                {
                    b.Property<int>("Case_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateClosed")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Topic")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Case_id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Contacts", b =>
                {
                    b.Property<int>("Contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Contact_id");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Emails", b =>
                {
                    b.Property<int>("Email_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Email_id");

                    b.HasIndex("CaseId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Licenses", b =>
                {
                    b.Property<int>("License_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeriesNumber")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("License_id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ProductId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Notes", b =>
                {
                    b.Property<int>("Note_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Note_id");

                    b.HasIndex("CaseId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Products", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Report", b =>
                {
                    b.Property<int>("Report_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Parameters")
                        .IsRequired()
                        .HasColumnType("json");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Report_id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Sla_contracts", b =>
                {
                    b.Property<int>("Sla_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("minReactionTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("minSolveTime")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Sla_id");

                    b.HasIndex("AccountId");

                    b.ToTable("Sla_contracts");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Users", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Cases", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Accounts", "Account")
                        .WithMany("Cases")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moc_DynamicCustomerService.Models.Contacts", "Contact")
                        .WithMany("Cases")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moc_DynamicCustomerService.Models.Users", "User")
                        .WithMany("Case")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Contact");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Contacts", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Accounts", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Emails", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Cases", "Cases")
                        .WithMany("Emails")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cases");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Licenses", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Accounts", "Account")
                        .WithMany("Licenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moc_DynamicCustomerService.Models.Products", "Products")
                        .WithMany("Licenses")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Notes", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Cases", "Case")
                        .WithMany("Notes")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moc_DynamicCustomerService.Models.Users", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Report", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Users", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Sla_contracts", b =>
                {
                    b.HasOne("Moc_DynamicCustomerService.Models.Accounts", "Account")
                        .WithMany("Sla_contracts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Accounts", b =>
                {
                    b.Navigation("Cases");

                    b.Navigation("Contacts");

                    b.Navigation("Licenses");

                    b.Navigation("Sla_contracts");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Cases", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Contacts", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Products", b =>
                {
                    b.Navigation("Licenses");
                });

            modelBuilder.Entity("Moc_DynamicCustomerService.Models.Users", b =>
                {
                    b.Navigation("Case");

                    b.Navigation("Notes");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
