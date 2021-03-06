USE [master]
GO
/****** Object:  Database [KarnalTravel]    Script Date: 4/20/2019 3:42:08 PM ******/
CREATE DATABASE [KarnalTravel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KarnalTravel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KarnalTravel.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KarnalTravel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KarnalTravel_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KarnalTravel] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KarnalTravel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KarnalTravel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KarnalTravel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KarnalTravel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KarnalTravel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KarnalTravel] SET ARITHABORT OFF 
GO
ALTER DATABASE [KarnalTravel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KarnalTravel] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KarnalTravel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KarnalTravel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KarnalTravel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KarnalTravel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KarnalTravel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KarnalTravel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KarnalTravel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KarnalTravel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KarnalTravel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KarnalTravel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KarnalTravel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KarnalTravel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KarnalTravel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KarnalTravel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KarnalTravel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KarnalTravel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KarnalTravel] SET RECOVERY FULL 
GO
ALTER DATABASE [KarnalTravel] SET  MULTI_USER 
GO
ALTER DATABASE [KarnalTravel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KarnalTravel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KarnalTravel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KarnalTravel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'KarnalTravel', N'ON'
GO
USE [KarnalTravel]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Audlts] [varchar](50) NULL,
	[Kids] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Message] [varchar](max) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Answer1] [varchar](50) NULL,
	[Answer2] [varchar](50) NULL,
	[Answer3] [varchar](50) NULL,
	[Answer4] [varchar](50) NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HotelImage]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HotelImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](max) NULL,
	[HotelId] [int] NULL,
 CONSTRAINT [PK_HotelImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HotelOrders]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[HotelId] [int] NULL,
	[RequiredRooms] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_HotelOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](max) NULL,
	[RoomPrice] [int] NOT NULL,
	[PercentDiscount] [int] NOT NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ResortImage]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResortImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](max) NULL,
	[ResortId] [int] NULL,
 CONSTRAINT [PK_ResortImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resorts ]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resorts ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](max) NULL,
	[Location] [varchar](max) NULL,
	[RoomPrice] [int] NOT NULL,
	[PercentDiscount] [int] NOT NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RestaurantsOrders]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantsOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RestaurantsId] [int] NULL,
	[RequiredPercentSets] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_RestaurantsOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResturantImages]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResturantImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imgUrl] [varchar](100) NULL,
	[resturantId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resturants]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resturants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](max) NULL,
	[CountryId] [int] NULL,
	[PercentDiscount] [int] NULL,
 CONSTRAINT [PK_Resturants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ToristspotImages]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ToristspotImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[imgurl] [varchar](max) NULL,
	[Touristspotid] [int] NULL,
 CONSTRAINT [PK_ToristspotImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TouristSpotOrders]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristSpotOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TouristSpotsId] [int] NULL,
	[Person] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_TouristSpotOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TouristSpots]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TouristSpots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](max) NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_TouristSpots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransportImages]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransportImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](max) NULL,
	[TransportId] [int] NULL,
 CONSTRAINT [PK_TransportImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transportion]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transportion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BussName] [varchar](50) NULL,
	[Photo] [varchar](max) NULL,
	[Details] [varchar](max) NULL,
	[Price] [varchar](50) NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Transportion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[UserTypeId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 4/20/2019 3:42:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ContactUs] ON 

INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1006, N'Ahmed', N'Ahmed@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1007, N'Owais', N'Owais@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1008, N'Tanzeel', N'Tanzeel@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1009, N'Noman Ishaq', N'Nomanishaq241@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1010, N'Shiza', N'Shiza@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
INSERT [dbo].[ContactUs] ([Id], [Name], [Email], [Phone], [Audlts], [Kids], [Date], [Message]) VALUES (1011, N'Sufiyan', N'Sufiyan@gmail.com', N'03012116588', N'2', N'4 or more', N'2019-04-16', N'sir plz book a order resort')
SET IDENTITY_INSERT [dbo].[ContactUs] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Pakistan')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'India')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (3, N'China')
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([Id], [Name], [LastName], [Email], [Phone], [Answer1], [Answer2], [Answer3], [Answer4]) VALUES (5, N' Noman', N' ishaq', N'Nomanishaq241@gmail.com', N' 03012116588', N'Excellent', N'Excellent', N'Good', N'Fair')
INSERT [dbo].[Feedbacks] ([Id], [Name], [LastName], [Email], [Phone], [Answer1], [Answer2], [Answer3], [Answer4]) VALUES (10, N'Ali', N'khan', N'ali@gmail.com', N'03012116588', N'Excellent', N'Good', N'Fair', N'Poor')
INSERT [dbo].[Feedbacks] ([Id], [Name], [LastName], [Email], [Phone], [Answer1], [Answer2], [Answer3], [Answer4]) VALUES (12, N'Ahmed', N'khan', N'Ahmed@gmail.com', N'03012116588', N'Excellent', N'Good', N'Fair', N'Poor')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
SET IDENTITY_INSERT [dbo].[Hotels] ON 

INSERT [dbo].[Hotels] ([Id], [Name], [Photo], [Details], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1005, N'Moderne, minimalistische ', N'Hotel1(2).jpg', N'Luxury modern minimalist house with swimming pool and beautiful sea view.', 1500, 1500, 2)
INSERT [dbo].[Hotels] ([Id], [Name], [Photo], [Details], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1006, N'Island Villa At Sunrise', N'Hotel2.jpg', N'Tropical Island Home With Infinity Pool.', 1800, 10, 1)
INSERT [dbo].[Hotels] ([Id], [Name], [Photo], [Details], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1007, N'Adembenemende ', N'Hotel3.jpg', N'Beautiful caucasian woman with an asian style conical hat sitting on a longtail boat and enjoying a carefree summer day on the beach.', 1300, 20, 1)
INSERT [dbo].[Hotels] ([Id], [Name], [Photo], [Details], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1008, N'Onthouden van mijn reis', N'Hotel4.jpg', N'Memorising my trip in Sydney.', 1900, 10, 2)
SET IDENTITY_INSERT [dbo].[Hotels] OFF
SET IDENTITY_INSERT [dbo].[Resorts ] ON 

INSERT [dbo].[Resorts ] ([Id], [Name], [Photo], [Details], [Location], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1002, N'Celeb-favourite', N'Resort1.jpg', N'Celeb-favourite resort to give away designer shoes', N'Muree, Islamabad', 3, 15, 1)
INSERT [dbo].[Resorts ] ([Id], [Name], [Photo], [Details], [Location], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1003, N'Thunderbird Resort', N'Resort4.jpg', N'At the east of the metro, Thunderbird Resorts & Casinos - Rizal is just an hour''s drive away from Manila.', N'London ', 50000, 20, 2)
INSERT [dbo].[Resorts ] ([Id], [Name], [Photo], [Details], [Location], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1004, N'Vestibulum tellus', N'Resort3(3).jpg', N'Vestibulum tellus neque, sodales vel mauris at, rhoncus finibus augue.', N'sharah e faisal', 10000, 15, 1)
INSERT [dbo].[Resorts ] ([Id], [Name], [Photo], [Details], [Location], [RoomPrice], [PercentDiscount], [CountryId]) VALUES (1007, N'test', N'Resort2(5).jpg', N'ifsjhhsjfh', N'karachi', 2, 10, 1)
SET IDENTITY_INSERT [dbo].[Resorts ] OFF
SET IDENTITY_INSERT [dbo].[Resturants] ON 

INSERT [dbo].[Resturants] ([Id], [Name], [Photo], [Details], [CountryId], [PercentDiscount]) VALUES (2016, N'Karachi', N'Resturant1.jpg', N'Clear Wine Glass on Table', 1, NULL)
INSERT [dbo].[Resturants] ([Id], [Name], [Photo], [Details], [CountryId], [PercentDiscount]) VALUES (2017, N'Kaybees', N'Resturant2.jpg', N'Inside view of Restaurant ', 1, NULL)
INSERT [dbo].[Resturants] ([Id], [Name], [Photo], [Details], [CountryId], [PercentDiscount]) VALUES (2018, N'Eton', N'Resturant3.jpg', N'Come hang out at El Original, where anyone from employees of Google', 1, NULL)
INSERT [dbo].[Resturants] ([Id], [Name], [Photo], [Details], [CountryId], [PercentDiscount]) VALUES (2020, N'Karachi Foods', N'Resturant2(2).jpg', N'Karachi naseeb biryani Main Market', 1, NULL)
SET IDENTITY_INSERT [dbo].[Resturants] OFF
SET IDENTITY_INSERT [dbo].[ToristspotImages] ON 

INSERT [dbo].[ToristspotImages] ([Id], [imgurl], [Touristspotid]) VALUES (1002, N'44587754_348246285934862_189872713085485056_n(2).jpg', 1005)
INSERT [dbo].[ToristspotImages] ([Id], [imgurl], [Touristspotid]) VALUES (1003, N'48916119_282239099127376_4996709675937300480_n.png', 1005)
SET IDENTITY_INSERT [dbo].[ToristspotImages] OFF
SET IDENTITY_INSERT [dbo].[TouristSpots] ON 

INSERT [dbo].[TouristSpots] ([Id], [Name], [Photo], [Details], [CountryId]) VALUES (1005, N'Cloud 9 Surf Spot ', N'Trouistpot1(2).jpg', N'Cloud 9 is the place to be if you want to experience surfing in Siargao. ', 1)
INSERT [dbo].[TouristSpots] ([Id], [Name], [Photo], [Details], [CountryId]) VALUES (1006, N'Taktak Falls ', N'Trouistpot2.jpg', N'If all that vitamin sea you''re soaking up in Siargao is still not enough, then you might want to add Taktak Falls to your itinerary', 1)
INSERT [dbo].[TouristSpots] ([Id], [Name], [Photo], [Details], [CountryId]) VALUES (1007, N'Magpupungko', N'Trouistpot3.jpg', N'Aside from the beach, Magpupungko is also visited for its tidal pools. During low tide, these natural swimming pools become the perfect place to take a relaxing dip because of its crystal-clear waters', 2)
INSERT [dbo].[TouristSpots] ([Id], [Name], [Photo], [Details], [CountryId]) VALUES (1009, N'qasim', N'44587754_348246285934862_189872713085485056_n.jpg', N'sdadfasdfasd', 1)
SET IDENTITY_INSERT [dbo].[TouristSpots] OFF
SET IDENTITY_INSERT [dbo].[Transportion] ON 

INSERT [dbo].[Transportion] ([Id], [BussName], [Photo], [Details], [Price], [CountryId]) VALUES (10, N' Daewoo Expres', N'Trannsport4(2).jpg', N'Daewoo Pakistan Express Bus Service Ltd (DPEBSL) ', N'3000', 1)
INSERT [dbo].[Transportion] ([Id], [BussName], [Photo], [Details], [Price], [CountryId]) VALUES (11, N'Northern Areas Transport Corporation', N'Trannsport3.jpg', N'Northern Areas Transport Corporation or NATCO is the largest transport company in Gilgit-Baltistan of Pakistan and Karakoram Highway, throughout the Northern Areas. ', N'3000', 1)
INSERT [dbo].[Transportion] ([Id], [BussName], [Photo], [Details], [Price], [CountryId]) VALUES (12, N'Pak-China bus ', N'Trannsport1(5).jpg', N'Pak-China bus service to be launched on Monday', N'800', 1)
SET IDENTITY_INSERT [dbo].[Transportion] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (1, N'Noman', N'nk2500930@gmail.com', N'admin', 1)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2, N'ali', N'ali@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (25, N'Nomanishaq', N'Nomanishaq241@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (26, N'sufiyan', N'sufiyan@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (27, N'Noman Ishaq', N'Nomanishaq241@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (1027, N'ahmed', N'Ahmed@gmail.com', N'1234', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2027, N'aptech', N'aptech@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2028, N'noman', N'noman@gmail.com', N'noman', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2029, N' Noman', N'noman@hotmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2030, N'Hasseb', N'Haseeb@gmail.com', N'1234', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2031, N'mani', N'mani@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [UserTypeId]) VALUES (2032, N'Ahmed', N'Ahmed@gmail.com', N'12345', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserTypes] ON 

INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (1, N'Admin     ')
INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (2, N'User      ')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
ALTER TABLE [dbo].[HotelImage]  WITH CHECK ADD  CONSTRAINT [FK_HotelImage_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[HotelImage] CHECK CONSTRAINT [FK_HotelImage_Hotels]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_Hotels]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_Users]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Countries]
GO
ALTER TABLE [dbo].[ResortImage]  WITH CHECK ADD  CONSTRAINT [FK_ResortImage_Resorts ] FOREIGN KEY([ResortId])
REFERENCES [dbo].[Resorts ] ([Id])
GO
ALTER TABLE [dbo].[ResortImage] CHECK CONSTRAINT [FK_ResortImage_Resorts ]
GO
ALTER TABLE [dbo].[Resorts ]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Resorts ] CHECK CONSTRAINT [FK_Reports_Countries]
GO
ALTER TABLE [dbo].[RestaurantsOrders]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantsOrders_Resturants] FOREIGN KEY([RestaurantsId])
REFERENCES [dbo].[Resturants] ([Id])
GO
ALTER TABLE [dbo].[RestaurantsOrders] CHECK CONSTRAINT [FK_RestaurantsOrders_Resturants]
GO
ALTER TABLE [dbo].[RestaurantsOrders]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantsOrders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RestaurantsOrders] CHECK CONSTRAINT [FK_RestaurantsOrders_Users]
GO
ALTER TABLE [dbo].[ResturantImages]  WITH CHECK ADD FOREIGN KEY([resturantId])
REFERENCES [dbo].[Resturants] ([Id])
GO
ALTER TABLE [dbo].[Resturants]  WITH CHECK ADD  CONSTRAINT [FK_Resturants_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Resturants] CHECK CONSTRAINT [FK_Resturants_Countries]
GO
ALTER TABLE [dbo].[ToristspotImages]  WITH CHECK ADD  CONSTRAINT [FK_ToristspotImages_TouristSpots] FOREIGN KEY([Touristspotid])
REFERENCES [dbo].[TouristSpots] ([Id])
GO
ALTER TABLE [dbo].[ToristspotImages] CHECK CONSTRAINT [FK_ToristspotImages_TouristSpots]
GO
ALTER TABLE [dbo].[TouristSpotOrders]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpotOrders_TouristSpots] FOREIGN KEY([TouristSpotsId])
REFERENCES [dbo].[TouristSpots] ([Id])
GO
ALTER TABLE [dbo].[TouristSpotOrders] CHECK CONSTRAINT [FK_TouristSpotOrders_TouristSpots]
GO
ALTER TABLE [dbo].[TouristSpotOrders]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpotOrders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[TouristSpotOrders] CHECK CONSTRAINT [FK_TouristSpotOrders_Users]
GO
ALTER TABLE [dbo].[TouristSpots]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpots_Countries1] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[TouristSpots] CHECK CONSTRAINT [FK_TouristSpots_Countries1]
GO
ALTER TABLE [dbo].[TransportImages]  WITH CHECK ADD  CONSTRAINT [FK_TransportImages_Transportion] FOREIGN KEY([TransportId])
REFERENCES [dbo].[Transportion] ([Id])
GO
ALTER TABLE [dbo].[TransportImages] CHECK CONSTRAINT [FK_TransportImages_Transportion]
GO
ALTER TABLE [dbo].[Transportion]  WITH CHECK ADD  CONSTRAINT [FK_Transportion_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Transportion] CHECK CONSTRAINT [FK_Transportion_Countries]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserTypes] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserTypes]
GO
USE [master]
GO
ALTER DATABASE [KarnalTravel] SET  READ_WRITE 
GO
