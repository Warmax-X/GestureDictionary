﻿// <auto-generated />
using GestureDictionary.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestureDictionary.Migrations
{
    [DbContext(typeof(GestureContext))]
    [Migration("20240213064756_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("GestureDictionary.Models.LetterGesture", b =>
                {
                    b.Property<string>("Letter")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PathToVideo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Letter");

                    b.ToTable("LetterGestures");
                });
#pragma warning restore 612, 618
        }
    }
}
