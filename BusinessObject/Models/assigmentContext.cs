using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class assigmentContext : DbContext
    {
        public assigmentContext()
        {
        }

        public assigmentContext(DbContextOptions<assigmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderService> OrderServices { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserTask> UserTasks { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DB"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoriesId)
                    .HasName("PK__Category__92BEE78A87A3F731");

                entity.ToTable("Category");

                entity.Property(e => e.CategoriesId).HasColumnName("categories_id");

                entity.Property(e => e.CategoriesName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categories_name");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FbId)
                    .HasName("PK__Feedback__A81DB82D4702C7DC");

                entity.ToTable("Feedback");

                entity.Property(e => e.FbId).HasColumnName("fb_id");

                entity.Property(e => e.FbContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fb_content");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Feedback_User");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.CategoriesId).HasColumnName("categories_id");

                entity.Property(e => e.MenuItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_item");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_Menu_Categories");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Menu_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Comission)
                    .IsUnicode(false)
                    .HasColumnName("comission");

                entity.Property(e => e.EndTime)
                    .HasColumnType("date")
                    .HasColumnName("end_time");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Room)
                    .IsUnicode(false)
                    .HasColumnName("room");

                entity.Property(e => e.StartTime)
                    .HasColumnType("date")
                    .HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TotalFees).HasColumnName("total_fees");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_Order_Voucher");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.ToTable("Order_Service");

                entity.Property(e => e.OrderServiceId).HasColumnName("order_service_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderService_Order");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_OrderService_Service");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.TaskDetail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("task_detail");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_User_Status");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.ToTable("User_Task");

                entity.Property(e => e.UserTaskId).HasColumnName("user_task_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_UserTask_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTask_User");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("date")
                    .HasColumnName("expire_date");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("note");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
