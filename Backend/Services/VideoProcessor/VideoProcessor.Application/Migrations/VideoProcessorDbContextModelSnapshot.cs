﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VideoProcessor.Infrastructure;

#nullable disable

namespace VideoProcessor.Application.Migrations
{
    [DbContext(typeof(VideoProcessorDbContext))]
    partial class VideoProcessorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SequenceNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SequenceNumber");

                    b.ToTable("_TransactionalEvents", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("AvailableDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AvailableDate");

                    b.HasIndex("CreateDate");

                    b.HasIndex("LastSequenceNumber");

                    b.ToTable("_TransactionalEventsGroup", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Idempotency.IdempotentOperation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("_IdempotentOperation", (string)null);
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.ProcessedVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LengthSeconds")
                        .HasColumnType("integer");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VideoFileId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VideoId")
                        .HasColumnType("uuid");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("ProcessedVideos");
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AvailableDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LockVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("ProcessedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RetryCount")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("VideoFileUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AvailableDate");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProcessedDate");

                    b.HasIndex("Status");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.VideoProcessingStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Complete")
                        .HasColumnType("boolean");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("VideoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoProcessingStep");
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.VideoThumbnail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<Guid>("ImageFileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("VideoId")
                        .HasColumnType("uuid");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoThumbnails");
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventData", b =>
                {
                    b.HasOne("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", null)
                        .WithMany("TransactionalEvents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Infrastructure.TransactionalEvents.TransactionalEvent", "Event", b1 =>
                        {
                            b1.Property<long>("TransactionalEventDataId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Category")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Category");

                            b1.Property<string>("Data")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Data");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Type");

                            b1.HasKey("TransactionalEventDataId");

                            b1.HasIndex("Category");

                            b1.ToTable("_TransactionalEvents");

                            b1.WithOwner()
                                .HasForeignKey("TransactionalEventDataId");
                        });

                    b.Navigation("Event")
                        .IsRequired();
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.ProcessedVideo", b =>
                {
                    b.HasOne("VideoProcessor.Domain.Models.Video", null)
                        .WithMany("Videos")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.Video", b =>
                {
                    b.OwnsOne("VideoProcessor.Domain.Models.VideoInfo", "VideoInfo", b1 =>
                        {
                            b1.Property<Guid>("VideoId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Height")
                                .HasColumnType("integer");

                            b1.Property<int>("LengthSeconds")
                                .HasColumnType("integer");

                            b1.Property<long>("Size")
                                .HasColumnType("bigint");

                            b1.Property<int>("Width")
                                .HasColumnType("integer");

                            b1.HasKey("VideoId");

                            b1.ToTable("Videos");

                            b1.WithOwner()
                                .HasForeignKey("VideoId");
                        });

                    b.OwnsOne("VideoProcessor.Domain.Models.VideoPreviewThumbnail", "PreviewThumbnail", b1 =>
                        {
                            b1.Property<Guid>("VideoId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Height")
                                .HasColumnType("integer")
                                .HasColumnName("PreviewThumbnailHeight");

                            b1.Property<Guid>("ImageFileId")
                                .HasColumnType("uuid")
                                .HasColumnName("PreviewThumbnailImageFileId");

                            b1.Property<float>("LengthSeconds")
                                .HasColumnType("real")
                                .HasColumnName("PreviewThumbnailLengthSeconds");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PreviewThumbnailLengthUrl");

                            b1.Property<int>("Width")
                                .HasColumnType("integer")
                                .HasColumnName("PreviewThumbnailWidth");

                            b1.HasKey("VideoId");

                            b1.ToTable("Videos");

                            b1.WithOwner()
                                .HasForeignKey("VideoId");
                        });

                    b.Navigation("PreviewThumbnail");

                    b.Navigation("VideoInfo");
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.VideoProcessingStep", b =>
                {
                    b.HasOne("VideoProcessor.Domain.Models.Video", null)
                        .WithMany("ProcessingSteps")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.VideoThumbnail", b =>
                {
                    b.HasOne("VideoProcessor.Domain.Models.Video", null)
                        .WithMany("Thumbnails")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.EFCore.TransactionalEvents.Models.TransactionalEventsGroup", b =>
                {
                    b.Navigation("TransactionalEvents");
                });

            modelBuilder.Entity("VideoProcessor.Domain.Models.Video", b =>
                {
                    b.Navigation("ProcessingSteps");

                    b.Navigation("Thumbnails");

                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
