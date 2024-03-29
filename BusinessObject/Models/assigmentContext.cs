﻿using System;
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
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetailMenu> OrderDetailMenus { get; set; } = null!;
        public virtual DbSet<OrderDetailService> OrderDetailServices { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<StatusOrder> StatusOrders { get; set; } = null!;
        public virtual DbSet<StatusRoom> StatusRooms { get; set; } = null!;
        public virtual DbSet<StatusUser> StatusUsers { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserOrder> UserOrders { get; set; } = null!;
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
                    .HasName("PK__Category__92BEE78A5DD7447F");

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
                    .HasName("PK__Feedback__A81DB82DAAF9DF30");

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

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_Menu_Category");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.EndTime)
                    .HasColumnType("date")
                    .HasColumnName("end_time");

                entity.Property(e => e.StartTime)
                    .HasColumnType("date")
                    .HasColumnName("start_time");

                entity.Property(e => e.StatusOrderId).HasColumnName("status_order_id");

                entity.Property(e => e.TotalFees).HasColumnName("total_fees");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.HasOne(d => d.StatusOrder)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusOrderId)
                    .HasConstraintName("FK_Order_StatusOrder");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_Order_Voucher");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.Commission).HasColumnName("commission");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_OrderDetail_Room");
            });

            modelBuilder.Entity<OrderDetailMenu>(entity =>
            {
                entity.ToTable("Order_Detail_Menu");

                entity.Property(e => e.OrderDetailMenuId).HasColumnName("order_detail_menu_id");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrderDetailMenus)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_OrderDetailMenu_Menu");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.OrderDetailMenus)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK_OrderDetailMenu_OrderDetail");
            });

            modelBuilder.Entity<OrderDetailService>(entity =>
            {
                entity.ToTable("Order_Detail_Services");

                entity.Property(e => e.OrderDetailServiceId).HasColumnName("order_detail_service_id");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.OrderDetailServices)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK_OrderDetailService_OrderDetail");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderDetailServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_OrderDetailService_Service");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("room_name");

                entity.Property(e => e.StatusRoomId).HasColumnName("status_room_id");

                entity.HasOne(d => d.StatusRoom)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.StatusRoomId)
                    .HasConstraintName("FK_Room_StatusRoom");
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

            modelBuilder.Entity<StatusOrder>(entity =>
            {
                entity.ToTable("Status_Order");

                entity.Property(e => e.StatusOrderId).HasColumnName("status_order_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<StatusRoom>(entity =>
            {
                entity.ToTable("Status_Room");

                entity.Property(e => e.StatusRoomId).HasColumnName("status_room_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<StatusUser>(entity =>
            {
                entity.ToTable("Status_User");

                entity.Property(e => e.StatusUserId).HasColumnName("status_user_id");

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

                entity.Property(e => e.StatusUserId).HasColumnName("status_user_id");

                entity.HasOne(d => d.StatusUser)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusUserId)
                    .HasConstraintName("FK_User_StatusUser");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.ToTable("User_Order");

                entity.Property(e => e.UserOrderId).HasColumnName("user_order_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_User_Order_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Order_User");
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
                    .HasConstraintName("FK_User_Task_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Task_User");
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
