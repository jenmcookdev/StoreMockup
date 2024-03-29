IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Catagories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Catagories]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 5/20/2019 12:50:17 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Statuses]') AND type in (N'U'))
DROP TABLE [dbo].[Statuses]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2019 12:50:17 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2019 12:50:17 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Database [DB_A4775E_ustore]    Script Date: 5/20/2019 12:50:17 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'DB_A4775E_ustore')
DROP DATABASE [DB_A4775E_ustore]
GO
/****** Object:  Database [DB_A4775E_ustore]    Script Date: 5/20/2019 12:50:17 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DB_A4775E_ustore')
BEGIN
CREATE DATABASE [DB_A4775E_ustore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A4775E_ustore', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DB_A4775E_ustore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_A4775E_ustore_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DB_A4775E_ustore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [DB_A4775E_ustore] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A4775E_ustore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A4775E_ustore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A4775E_ustore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A4775E_ustore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A4775E_ustore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_A4775E_ustore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A4775E_ustore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A4775E_ustore] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A4775E_ustore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A4775E_ustore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A4775E_ustore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A4775E_ustore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2019 12:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NOT NULL,
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_Catagories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2019 12:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [varchar](max) NULL,
	[Price] [money] NULL,
	[UnitsInStock] [smallint] NOT NULL,
	[ProductImage] [varchar](75) NULL,
	[StatusID] [int] NOT NULL,
	[CategoryID] [int] NULL,
	[Notes] [varchar](500) NULL,
	[ReferenceURL] [varchar](1024) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 5/20/2019 12:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Statuses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Statuses](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](30) NOT NULL,
	[StatusOrder] [tinyint] NOT NULL,
	[Notes] [varchar](100) NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (1, N'Blanket', N'Blanket')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (2, N'Pants', N'Pants with white fur')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (3, N'Hat', N'wool - straw hat')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (4, N'Shoes', N'sneakers')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (5, N'Curtains', N'two panel curtains')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (6, N'Rug', N'Oval rug')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (7, N'Bath Towel', N'Large Terry Cloth Towel')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (9, N'Other', N'Any item not of our regular categories')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (10, N'Food', N'Perishable and non-perishable foods')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Notes]) VALUES (11, N'Art', N'Crafts and art')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (4, N'Furry Toes', N'Sneakers with a nice layer of feline and canine fur covering them', 52.6100, 10, N'NoImage.jpg', 2, 4, N'Sell remaining stock, item no longer available for future orders', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (5, N'Hair Breezy', N'Two panel curtains, 24 x 64', 20.6700, 15, N'NoImage.jpg', 1, 5, N'See how these sell, order different sizes', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (6, N'Weaved Oval Rug', N'Oval rug woven of the finest Collie fur', 41.7300, 5, N'NoImage.jpg', 1, 6, N'Order more', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (15, N'Fuzzy Wuzzy', N'Fuzzy Fur Hat', 2.5500, 9, N'Noimage.jpg', 1, 3, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (17, N'Top Warmer', N'Wool lined straw hat to keep noggin warm', 35.8700, 0, N'Noimage.jpg', 4, 3, N'No longer available', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (19, N'By The Boot', N'By the Boot''s exceptional craftsmanship adds an extra touch of earth mixed in to the pet hair heightening the appeal. A careful balance of earth and hair are combined and thoroughly mixed in an actual boot! Each By the Boot has a robust musty earthy smell and is a must for any nature lover.', 250.0000, 4, N'https://i.imgur.com/FkT60eL.jpg', 1, 9, N'May contain bugs', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (20, N'Natural Fuzzy Blanket', N'Snuggle up in our luxury all natural fur blanket. The fibers were weaved together with a combination of canine and feline fur for added flair. The cozy blanket is a great comfort on a cold day and can be draped over a chair to snazzy up any room. The pre-shrunk fibers are machine washable and fade resistant.', 70.0000, 6, N'https://i.imgur.com/r18YKZE.jpg', 1, 1, N'Colors vary', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (21, N'Lantern', N'The Lantern adds a unique way to display the hair you purchase. No longer limited to just laying around on top of surfaces, your pet hair can now be hung anywhere you want to add a touch of class. The Lantern is easy to open and the pet hair can be changed out as often as you like. The Lantern comes pre-loaded with top-quality fur in this eye catching conversation piece.', 150.0000, 15, N'https://i.imgur.com/FfAlZrz.jpg', 1, 9, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (22, N'Lurking', N'Years of scientific research lead to the development of Lurking. It is specially designed to hide behind furniture and in corners where it will be unnoticed until you decide to rearrange your decor. Regardless the color this stealthy hair will always be where you least expect it. You will swear it moves on its own!', 110.0000, 11, N'https://i.imgur.com/4d5lRi8.jpg', 1, 9, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (23, N'Edifurble', N'Edifurble is the perfect garnish for any meal. Make your next garden party a success and buy enough to satisfy all your guests. Edifurble can also be used as an additive for any recipe or sprinkled on top for added pizazz.', 3.0000, 215, N'https://i.imgur.com/EWVgHat.jpg', 1, 10, N'Sold in bulk groupings.  Keep good stock.', NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (24, N'Fur Ritzy', N'For those of exquisite taste that want a bit of country to their urban life, Fur Ritzy is just what you need. The equine fur is carefully harvested by the most sophisticated technology and allowed to ripen in the sun to seal in the natural hues. With this on your lawn, you’ll be the envy of your neighborhood. Available by the pound.', 35.0000, 3, N'https://i.imgur.com/SQOQlcT.jpg', 1, 9, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (25, N'Fluffer Puff', N'Harvested from the purest of royal felines. This fluff is only for those of discerning taste. Can be molded to display as one artistic piece or separated into smaller displays.', 33.0000, 11, N'https://i.imgur.com/J02Zxm2.jpg', 1, 11, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (26, N'Almost Invisible', N'Available in a variety of colors, Almost Invisible can be matched to blend in with your decor. Our team of specially trained associates are available to assist in finding the most perfect match and take the guesswork out of which fur is right for you.', 9.0000, 31, N'https://i.imgur.com/6OogXcm.jpg', 1, 9, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (27, N'Back40', N'The Back40 is attuned in multiple complimentary colors for those seeking more variety in life. This wonderous mix of tones provides the perfect conversation piece, whether sprinkled across furniture or left in well thought out clumps inside or out. Once applied you''d swear there was enough to cover the back forty.', 55.0000, 24, N'https://i.imgur.com/BNgF5GS.jpg', 1, 9, NULL, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [UnitsInStock], [ProductImage], [StatusID], [CategoryID], [Notes], [ReferenceURL]) VALUES (28, N'Brushed', N'Brushed is 8 ounces of luxurious soft gray fur of the feline variety. These fine hairs will find their way into every inch of your home. You can try to contain them in one room but the light hair will float on the smallest of wind and travel from one room to the next.', 15.0000, 41, N'https://i.imgur.com/V9GWG02.jpg', 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (1, N'In Stock', 1, N'Items available to buy.')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (2, N'Out of Stock', 2, N'No items currently available for immediate purchase and delivery.')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (3, N'Backordered', 3, N'Items already in progress to fulfill existing orders or future orders.')
INSERT [dbo].[Statuses] ([StatusID], [StatusName], [StatusOrder], [Notes]) VALUES (4, N'Discontinued', 4, N'Item can no longer be purchased - completely unavailable.')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Catagories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Catagories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Catagories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Catagories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Statuses] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Statuses] ([StatusID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Products_Statuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Statuses]
GO
ALTER DATABASE [DB_A4775E_ustore] SET  READ_WRITE 
GO
