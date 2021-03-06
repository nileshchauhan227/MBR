SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseReturnMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseReturnMaster](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[PurchaseID] [bigint] NOT NULL,
	[ReasonForReturn] [varchar](250) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PurchaseReturnMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CashExpense]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CashExpense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpDetail] [varchar](250) NOT NULL,
	[ExpDate] [datetime] NOT NULL,
	[ReceiverName] [varchar](100) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__CashExpe__3214EC077F60ED59] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerMaster](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](150) NULL,
	[CustomerAddress] [varchar](1000) NULL,
	[EmailId] [varchar](150) NULL,
	[PhoneNo] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CompanyMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](150) NULL,
	[CompanyAddress] [varchar](max) NULL,
	[PhoneNo] [varchar](15) NULL,
	[MobileNo] [varchar](10) NULL,
	[EmailId] [varchar](30) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__CompanyM__3214EC070519C6AF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodeType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CodeType](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](10) NULL,
 CONSTRAINT [PK_CodeType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
if not exists (select * from CodeType)
begin 
	INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (1, N'Unit', N'UN')
	INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (2, N'Group', N'GR')
	INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (3, N'Party', N'PARTY')
	INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (4, N'Firm', N'FM')
	INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (5, N'Table', N'TB')
end 

SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodeMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CodeMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](10) NULL,
	[CodeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_CodeMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetExpenseDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetExpenseDetail] (@expdate AS DATE)
AS
BEGIN
	SELECT ExpDetail
		,Amount
	FROM CashExpense
	WHERE cast(ExpDate AS DATE) = cast(@expdate AS DATE)
	and IsDeleted = 0 
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseMaster](
	[PurchaseID] [bigint] IDENTITY(1,1) NOT NULL,
	[PONumber] [varchar](100) NULL,
	[PODate] [datetime] NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[InvoiceDate] [datetime] NULL,
	[ReceivedBy] [varchar](100) NOT NULL,
	[Remarks] [varchar](500) NULL,
	[InvoiceAmount] [decimal](18, 2) NOT NULL,
	[TransactionType] [smallint] NOT NULL,
	[Career] [varchar](500) NOT NULL,
	[VendorID] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_PurchaseMaster] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetConfiguration]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetConfiguration]
AS
BEGIN
	SELECT (
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''InvoiceName''
			) AS InvoiceName
		,(
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''ReportHeader''
			) AS ShopName
		,(
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''Add1''
			) AS Add1
		,(
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''Add2''
			) AS Add2
		,(
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''Phone''
			) AS Phone
		,(
			SELECT TOP 1 ConfigurationValue
			FROM ConfigurationSetting
			WHERE ConfigurationKey = ''Print Message''
			) AS PrintMessage
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTotalExpense]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--GetTotalSales ''2016-10-22''
CREATE PROCEDURE [dbo].[GetTotalExpense] (@date DATE)
AS
BEGIN
	SET @date = getdate()

	--declare @startdate datetime = ''2016-10-23'', @enddate datetime = ''2016-10-23''
	SELECT cast(ExpDate AS DATE) AS ExpDate
		,SUM(Amount) AS Amount
	FROM CashExpense
	WHERE cast(ExpDate AS DATE) BETWEEN @date AND @date and IsDeleted = 0
	GROUP BY cast(ExpDate AS DATE)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetShopDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetShopDetail] (
	@fromdate DATETIME
	,@toDate DATETIME
	)
AS
BEGIN
	SELECT ConfigurationValue
		,@fromdate AS fromdate
		,@toDate AS todate
	FROM ConfigurationSetting
	WHERE ConfigurationKey = ''ShopName''
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KOTMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KOTMaster](
	[KOTID] [int] IDENTITY(1,1) NOT NULL,
	[SRNumber] [int] NOT NULL,
	[KOTDateTime] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TableID] [int] NOT NULL,
	[IsBillGenerated] [bit] NULL,
	[TobeMaintained] [bit] NULL,
	[BillID] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_KOTMaster] PRIMARY KEY CLUSTERED 
(
	[KOTID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemMaster](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [varchar](50) NULL,
	[ItemName] [varchar](100) NULL,
	[GroupID] [int] NOT NULL,
	[UnitID] [int] NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Rate] [decimal](18, 2) NULL,
	[OtherDiscount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[FirmId] [int] NULL,
	[ServiceTax] [bit] NULL,
	[OpeningBalance] [decimal](18, 0) NULL,
	[IsSaleable] [bit] NULL,
	[IsUniqueSerialNumber] [bit] NULL,
 CONSTRAINT [PK_ItemMaster] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillMaster](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[Series] [nvarchar](50) NOT NULL,
	[Rnumber] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Party] [varchar](50) NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[TableID] [int] NULL,
	[WaiterID] [int] NULL,
	[MobileNo] [varchar](10) NULL,
	[NoOfItems] [int] NULL,
	[GrossAmount] [decimal](18, 2) NULL,
	[DiscountPercentage] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[DiscountReason] [varchar](100) NULL,
	[Tax] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[CashReceived] [decimal](18, 2) NULL,
	[RoundOff] [decimal](18, 2) NULL,
	[IsPrinted] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BillMaster] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillDetails](
	[BillDetailID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[IsDeleted] [bit] NULL,
	[ItemCode] [varchar](50) NULL,
 CONSTRAINT [PK_BillDetails] PRIMARY KEY CLUSTERED 
(
	[BillDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KOTDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KOTDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KOTID] [int] NULL,
	[ItemID] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[IsServed] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_KOTDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseDetail](
	[PurchaseDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseID] [bigint] NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemCode] [varchar](50) NULL,
	[Description] [varchar](500) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[PricePerItem] [decimal](18, 2) NULL,
	[MRPPerItem] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseReturnDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseReturnDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnMasterID] [bigint] NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemCode] [varchar](50) NOT NULL,
	[Qty] [decimal](18, 2) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_PurchaseReturnDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesReturnMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesReturnMaster](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[BillID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDate] [bigint] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SalesReturnMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockBalance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockBalance](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemCode] [varchar](50) NULL,
	[TransactionDate] [datetime] NOT NULL,
	[OpeningQty] [decimal](18, 2) NULL,
	[Purchase] [decimal](18, 2) NULL,
	[PurchaseReturn] [decimal](18, 2) NULL,
	[Sales] [decimal](18, 2) NULL,
	[SalesReturn] [decimal](18, 2) NULL,
	[ClosingQty] [decimal](18, 2) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nchar](10) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__StockBal__3214EC273D5E1FD2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTotalSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetTotalSales] (@date DATE )
AS
BEGIN
	--declare @startdate datetime = ''2016-10-23'', @enddate datetime = ''2016-10-23''
	SELECT cast(InvoiceDate AS DATE) AS InvoiceDate
		,SUM(NetAmount) AS TotalReceipt
	FROM BillMaster
	WHERE cast(InvoiceDate AS DATE) BETWEEN @date AND @date
	GROUP BY cast(InvoiceDate AS DATE)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpodateStockBalance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--UpodateStockBalance  ''c''
CREATE PROCEDURE [dbo].[UpodateStockBalance] (@type CHAR(1))
AS
BEGIN
	DECLARE @date DATE = getdate()

	IF (@type = ''O'')
	BEGIN
		IF NOT EXISTS (
				SELECT *
				FROM StockBalance
				WHERE cast(TransactionDate AS DATE) = @date
				)
		BEGIN
			INSERT INTO StockBalance (
				Itemid
				,Transactiondate
				,OpeningQty
				,createdBy
				,CreatedDate
				)
			SELECT ItemID
				,@date
				,OpeningBalance
				,1
				,@date
			FROM ItemMaster
		END
	END
	ELSE
	BEGIN
		UPDATE s
		SET --s.OpeningQty = im.OpeningBalance
			s.Purchase = isnull(purchase.Quantity,0)
			,s.PurchaseReturn = isnull(preturn.Quantity,0)
			,s.Sales = isnull(sales.Quantity,0)
			,s.ClosingQty = (isnull(s.OpeningQty,0) + isnull(purchase.Quantity,0)) - (isnull(preturn.Quantity,0) + isnull(sales.Quantity,0))
		FROM StockBalance s
		INNER JOIN ItemMaster im ON s.ItemID = im.ItemID
			AND cast(s.TransactionDate AS DATE) = @date
		LEFT JOIN (
			SELECT pd.ItemID
				,sum(isnull(pd.Quantity,0)) AS Quantity
			FROM PurchaseMaster pm
			INNER JOIN PurchaseDetail pd ON pm.PurchaseID = pd.PurchaseID
			WHERE cast(pm.CreatedDate AS DATE) = @date
			GROUP BY pd.ItemID
			) AS purchase ON im.ItemID = purchase.ItemID
		LEFT JOIN (
			SELECT bd.ItemID
				,sum(isnull(bd.Quantity,0)) Quantity
			FROM BillMaster bm
			INNER JOIN BillDetails bd ON bm.BillID = bd.BillID
			WHERE cast(bm.InvoiceDate AS DATE) = @date
			GROUP BY bd.ItemID
			) AS sales ON im.ItemID = sales.ItemID
		LEFT JOIN (
			SELECT ItemID
				,sum(isnull(Qty,0)) AS Quantity
			FROM PurchaseReturnMaster prm
			INNER JOIN PurchaseReturnDetail prd ON prm.ID = prd.PurchaseReturnMasterID
			WHERE cast(prm.CreatedDate AS DATE) = @date
			GROUP BY ItemID
			) AS preturn ON im.ItemID = preturn.ItemID
	END
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesSummary]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--[SalesSummary] ''2016-11-13'' ,''2016-11-13''
CREATE PROC [dbo].[SalesSummary] (
	@FromDate DATETIME
	,@ToDate DATETIME
	)
AS
BEGIN
	SELECT DISTINCT Rnumber AS InvoiceNo
		,InvoiceDate
		,Party
		,GrossAmount
		,b.Discount
		,RoundOff
		,NetAmount
		,@FromDate
		,@ToDate
		,i.FirmId
		,f.NAME AS FirmName
		,b.Tax
		,NetAmount - RoundOff AS CashReceived
	FROM BillMaster b
	JOIN BillDetails d ON d.BillID = b.BillID
	JOIN ItemMaster i ON i.ItemID = d.ItemID
	JOIN CodeMaster f ON f.ID = i.FirmId
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, InvoiceDate) <= CONVERT(DATE, @ToDate)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDetailsOfPurchase]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[GetDetailsOfPurchase]

	@FromDate DATETIME	,--= ''2016-07-29'',
	@ToDate DATETIME --= ''2016-08-01''
As
Begin
		Select InvoiceNumber,PODate, InvoiceAmount,i.ItemCode,
		ItemName,d.Quantity,i.Rate from PurchaseMaster p
		inner join PurchaseDetail d on d.PurchaseID = p.PurchaseID
		inner join ItemMaster i on i.ItemID = d.ItemID
		where  CONVERT(DATE, CreatedDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, CreatedDate) <= CONVERT(DATE, @ToDate)

End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesReturnDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SalesReturnDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesReturnMasterID] [bigint] NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemCode] [varchar](50) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[PricePerUnit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SalesReturnDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesRegister]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--[SalesRegister] ''2016-11-13'' ,''2016-11-13''
CREATE PROC [dbo].[SalesRegister] @FromDate DATETIME
	,@ToDate DATETIME
AS
BEGIN
	SELECT DISTINCT Rnumber AS InvoiceNo
		,InvoiceDate
		,Party
		,GrossAmount
		,b.Discount
		,RoundOff
		,NetAmount
		,@FromDate
		,@ToDate
		--,i.FirmId
		--,f.NAME AS FirmName
		,b.Tax
		,b.CashReceived
	FROM BillMaster b
	JOIN BillDetails d ON d.BillID = b.BillID
	JOIN ItemMaster i ON i.ItemID = d.ItemID
	JOIN CodeMaster f ON f.ID = i.FirmId
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, InvoiceDate) <= CONVERT(DATE, @ToDate)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemwSalesiseReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--[ItemwSalesiseReport] ''2016-11-13''  ,''2016-11-13''  
CREATE PROC [dbo].[ItemwSalesiseReport] @FromDate DATETIME
	,-- = ''2016-07-29'',  
	@ToDate DATETIME -- = ''2016-08-01''  
AS
BEGIN
	SELECT c.NAME
		,i.ItemCode
		,i.ItemName
		,Sum(d.Quantity) AS Quantity
		,avg(d.Rate) AS Rate
		,Sum(d.Quantity) * avg(d.Rate) AS Amount
		,i.ItemID
		,c.ID AS GroupID
		,c.NAME AS GroupName
		,f.NAME AS FirmName
		,f.ID
	--@FromDate  
	--,@ToDate  
	FROM ItemMaster i
	JOIN BillDetails d ON d.ItemID = i.ItemID
	JOIN CodeMaster c ON c.ID = i.GroupID
	JOIN BillMaster b ON b.BillID = d.BillID
	JOIN CodeMaster f ON f.ID = i.FirmId
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, b.InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, b.InvoiceDate) <= CONVERT(DATE, @ToDate)
	GROUP BY c.NAME
		,i.ItemCode
		,i.ItemName
		,i.ItemID
		,c.ID
		,c.NAME
		,f.NAME
		,f.ID
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemwiseReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--[ItemwiseReport] ''2016-11-13'',''2016-11-13''
CREATE PROC [dbo].[ItemwiseReport] @FromDate DATETIME --= ''2016-07-29'',
	,@ToDate DATETIME --= ''2016-08-01''
AS
BEGIN
	SELECT C.NAME AS ItemCode
		,SUM(D.Quantity) AS Quantity
		,SUM(D.Quantity * d.Rate) AS Amount
		,@FromDate
		,@ToDate
	FROM ItemMaster i
	JOIN BillDetails d ON d.ItemID = i.ItemID
	JOIN BillMaster b ON b.BillID = d.BillID
	JOIN CodeMaster C ON C.ID = I.GroupID
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, b.InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, InvoiceDate) <= CONVERT(DATE, @ToDate)
	GROUP BY C.NAME
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRunningKOT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetRunningKOT]
AS
BEGIN
	SELECT M.KOTID
		,M.SRNumber
		,C.NAME AS TableNumber
		,SUM(D.Quantity * ((I.Rate - I.OtherDiscount) - (I.Rate * I.OtherDiscount / 100))) AS NetAmount
	FROM KOTMaster M
	INNER JOIN KOTDetail D ON M.KOTID = D.KOTID
	INNER JOIN CodeMaster C ON M.TableID = c.ID
	INNER JOIN ItemMaster I ON D.ItemID = I.ItemID
	WHERE ISNULL(M.IsBillGenerated, 0) = 0
		AND cast(m.KOTDateTime AS DATE) = CAST(GETDATE() AS DATE)
		AND isnull(m.IsDeleted,0) = 0
		AND isnull(d.IsDeleted,0) = 0
	GROUP BY M.KOTID
		,M.SRNumber
		,C.NAME
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetKotRecordsList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--[GetKotRecordsList] ''2016-11-15''  
CREATE PROCEDURE [dbo].[GetKotRecordsList] @Date DATE
AS
BEGIN
	SELECT SRNumber
		,CONVERT(VARCHAR, KOTDateTime, 105) AS strKOTDate
		,CONVERT(VARCHAR, KOTDateTime, 24) AS strKOTTime
		,CONVERT(INT, sum(d.Quantity)) AS Quantity
		,ISNULL(m.TobeMaintained, 0) AS TobeMaintained
		,m.KOTID
		,CONVERT(NUMERIC(18, 2), SUM(D.Quantity * ((I.Rate - I.OtherDiscount) - (I.Rate * I.OtherDiscount / 100)))) AS NetAmount
	FROM KOTMaster m
	JOIN KOTdetail d ON d.KOTID = m.KOTID
	JOIN ItemMaster i ON i.ItemID = d.ItemID
	--where m.KOTID =21--   
	WHERE CONVERT(DATE, m.KOTDateTime) = CONVERT(DATE, @Date)
		AND ISNULL(m.IsBillGenerated, 0) = 0
		and isnull(m.IsDeleted,0) = 0 and isnull(d.IsDeleted,0) = 0
	GROUP BY m.KOTID
		,SRNumber
		,KOTDateTime
		,m.TobeMaintained --,Rate  , d.Quantity   
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBillDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetBillDetail] (@BillId INT)
AS
BEGIN
	SELECT M.Series
		,M.Rnumber
		,M.Party
		,D.ItemID
		,I.ItemCode
		,I.ItemName
		,D.Quantity
		,D.Rate
		,D.Quantity * D.Rate AS Amount
		,isnull(M.Discount,0) as Discount
		,isnull(M.Tax,0) as Tax
		,ROW_NUMBER() OVER (
			ORDER BY D.BillDetailID
			) AS runningnumber
		,M.NetAmount
		,M.CashReceived
		,M.RoundOff
		,M.InvoiceDate
	FROM BillMaster M
	INNER JOIN BillDetails D ON M.BillID = D.BillID
	INNER JOIN ItemMaster I ON D.ItemID = I.ItemID
	WHERE M.BillID = @BillId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EODReportByPaymentMode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--exec EODReportByPaymentMode ''2016-11-26'',''2016-11-26''
CREATE PROCEDURE [dbo].[EODReportByPaymentMode] (
	@FromDate DATE
	,@ToDate DATE
	)
AS
BEGIN
	SELECT P.NAME
		,cast(M.InvoiceDate AS DATE) AS InvoiceDate
		,sum(d.Quantity * d.Rate) AS GrossAmount
		,sum(D.Tax) AS Tax
		,sum((d.Quantity * d.Rate) + (ISNULL(D.Tax, 0))) AS NetAmount
	FROM BillMaster M
	INNER JOIN BillDetails D ON M.BillID = D.BillID
	INNER JOIN ItemMaster I ON D.ItemID = I.ItemID
	INNER JOIN CodeMaster F ON F.ID = I.FirmId
	INNER JOIN CodeMaster P ON M.PaymentMode = P.ID
	WHERE cast(M.InvoiceDate AS DATE) BETWEEN @FromDate AND @ToDate
	GROUP BY P.NAME
		,cast(M.InvoiceDate AS DATE)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EODReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--[EODReport] ''2016-10-25'', ''2016-10-25''
CREATE PROCEDURE [dbo].[EODReport] (
	@FromDate DATE
	,@ToDate DATE
	)
AS
BEGIN
	SELECT F.ID
		,F.NAME
		,cast(M.InvoiceDate AS DATE) as InvoiceDate
		--I.ItemID,i.ItemName, d.Quantity,   
		,sum(d.Quantity * d.Rate) AS NetAmount
		,sum(D.Tax) AS Tax
		,sum((d.Quantity * d.Rate) + (D.Tax)) AS GrossAmount
		,(
			SELECT SUM(Amount) AS Amount
			FROM CashExpense
			WHERE cast(ExpDate AS DATE) = @FromDate
			GROUP BY cast(ExpDate AS DATE)
			) AS cashExp
	FROM BillMaster M
	INNER JOIN BillDetails D ON M.BillID = D.BillID
	INNER JOIN ItemMaster I ON D.ItemID = I.ItemID
	INNER JOIN CodeMaster F ON F.ID = I.FirmId
	WHERE cast(M.InvoiceDate AS DATE) BETWEEN @FromDate AND @ToDate
	GROUP BY F.ID
		,F.NAME
		,cast(M.InvoiceDate AS DATE)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetailSalesReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[DetailSalesReport] @FromDate DATETIME
	,-- = ''2016-07-29'',
	@ToDate DATETIME --= ''2016-08-01''
AS
BEGIN
	SELECT Rnumber AS InvoiceNo
		,InvoiceDate
		,Party
		,d.Quantity
		,d.Quantity * d.rate as Amount
		,d.Rate
		,i.ItemCode
		,i.ItemName
		,c.NAME AS ItemCode
		,@FromDate
		,@ToDate
		,i.FirmId
		,f.NAME
	FROM BillMaster b
	JOIN BillDetails d ON d.BillID = b.BillID
	JOIN ItemMaster i ON i.ItemID = d.ItemID
	JOIN CodeMaster c ON c.ID = i.GroupID
	JOIN CodeMaster f ON f.ID = i.FirmId
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, InvoiceDate) <= CONVERT(DATE, @ToDate)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemBarcode]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemBarcode](
	[ItemID] [int] NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[PurchaseDetailID] [bigint] NULL,
	[IsSold] [bit] NULL,
	[Status] [smallint] NULL,
	[BillID] [int] NULL,
 CONSTRAINT [PK_ItemBarcode] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[BarCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceWiseSalesSummary]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[InvoiceWiseSalesSummary] @FromDate DATETIME
	,--= ''2016-07-29'',
	@ToDate DATETIME --= ''2016-08-01''
AS
BEGIN
	SELECT Rnumber AS InvoiceNo
		,InvoiceDate
		,Party
		,d.Quantity
		,(d.Rate * d.Quantity) AS Amount
		,i.ItemName
		,c.NAME
		,@FromDate
		,@ToDate
		,i.FirmId
		,f.NAME AS FirmName
	FROM BillMaster b
	JOIN BillDetails d ON d.BillID = b.BillID
	JOIN ItemMaster i ON i.ItemID = d.ItemID
	JOIN CodeMaster c ON c.ID = i.GroupID
	JOIN CodeMaster f ON f.ID = i.FirmId
	WHERE b.IsDeleted = 0
		AND d.IsDeleted = 0
		AND CONVERT(DATE, InvoiceDate) >= CONVERT(DATE, @FromDate)
		AND CONVERT(DATE, InvoiceDate) <= CONVERT(DATE, @ToDate)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupWiseSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--EXEC GroupWiseSales ''2016-07-01'',''2016-07-31''
CREATE PROCEDURE [dbo].[GroupWiseSales] (
	@fromDate DATE = NULL
	,@toDate DATE = NULL
	)
AS
BEGIN
	SELECT sum(D.Quantity * D.Amount) AS Amount
		,C.NAME
	FROM BillMaster M
	INNER JOIN BillDetails D ON M.BillID = D.BillID
	INNER JOIN ItemMaster I ON D.ItemID = I.ItemID
	INNER JOIN CodeMaster C ON I.GroupID = C.ID
	WHERE M.IsDeleted = 0
		AND d.IsDeleted = 0
		AND M.InvoiceDate >= (CASE WHEN @fromDate IS NOT NULL THEN @fromDate ELSE M.InvoiceDate END)
		AND M.InvoiceDate <= (CASE WHEN @toDate IS NOT NULL THEN @toDate ELSE M.InvoiceDate END)
	GROUP BY C.NAME
END

' 
END
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ItemBarcode_IsSold]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemBarcode]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ItemBarcode_IsSold]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ItemBarcode] ADD  CONSTRAINT [DF_ItemBarcode_IsSold]  DEFAULT ((0)) FOR [IsSold]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__ItemMaste__IsUni__619B8048]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ItemMaste__IsUni__619B8048]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ItemMaster] ADD  CONSTRAINT [DF__ItemMaste__IsUni__619B8048]  DEFAULT ((0)) FOR [IsUniqueSerialNumber]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_KOTMaster_IsBillGenerated]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_KOTMaster_IsBillGenerated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[KOTMaster] ADD  CONSTRAINT [DF_KOTMaster_IsBillGenerated]  DEFAULT ((0)) FOR [IsBillGenerated]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_KOTMaster_TobeMaintained]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_KOTMaster_TobeMaintained]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[KOTMaster] ADD  CONSTRAINT [DF_KOTMaster_TobeMaintained]  DEFAULT ((0)) FOR [TobeMaintained]
END


End
GO
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_PurchaseReturnMaster_IsDeleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseReturnMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PurchaseReturnMaster_IsDeleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PurchaseReturnMaster] ADD  CONSTRAINT [DF_PurchaseReturnMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
END


End
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillDetails_BillDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillDetails]'))
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_BillDetails] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillMaster] ([BillID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillDetails_BillDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillDetails]'))
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_BillDetails]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillDetails_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillDetails]'))
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_BillDetails_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillDetails_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillDetails]'))
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_BillDetails_ItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillMaster_TableID_CodeMaster_ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillMaster]'))
ALTER TABLE [dbo].[BillMaster]  WITH CHECK ADD  CONSTRAINT [FK_BillMaster_TableID_CodeMaster_ID] FOREIGN KEY([TableID])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillMaster_TableID_CodeMaster_ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillMaster]'))
ALTER TABLE [dbo].[BillMaster] CHECK CONSTRAINT [FK_BillMaster_TableID_CodeMaster_ID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillMaster_WaiterID_CodeMaster_ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillMaster]'))
ALTER TABLE [dbo].[BillMaster]  WITH CHECK ADD  CONSTRAINT [FK_BillMaster_WaiterID_CodeMaster_ID] FOREIGN KEY([WaiterID])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillMaster_WaiterID_CodeMaster_ID]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillMaster]'))
ALTER TABLE [dbo].[BillMaster] CHECK CONSTRAINT [FK_BillMaster_WaiterID_CodeMaster_ID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CodeMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[CodeMaster]'))
ALTER TABLE [dbo].[CodeMaster]  WITH CHECK ADD  CONSTRAINT [FK_CodeMaster_CodeMaster] FOREIGN KEY([CodeTypeID])
REFERENCES [dbo].[CodeType] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CodeMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[CodeMaster]'))
ALTER TABLE [dbo].[CodeMaster] CHECK CONSTRAINT [FK_CodeMaster_CodeMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemBarcode_BillMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemBarcode]'))
ALTER TABLE [dbo].[ItemBarcode]  WITH CHECK ADD  CONSTRAINT [FK_ItemBarcode_BillMaster] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillMaster] ([BillID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemBarcode_BillMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemBarcode]'))
ALTER TABLE [dbo].[ItemBarcode] CHECK CONSTRAINT [FK_ItemBarcode_BillMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemBarcode_PurchaseDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemBarcode]'))
ALTER TABLE [dbo].[ItemBarcode]  WITH CHECK ADD  CONSTRAINT [FK_ItemBarcode_PurchaseDetail] FOREIGN KEY([PurchaseDetailID])
REFERENCES [dbo].[PurchaseDetail] ([PurchaseDetailID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemBarcode_PurchaseDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemBarcode]'))
ALTER TABLE [dbo].[ItemBarcode] CHECK CONSTRAINT [FK_ItemBarcode_PurchaseDetail]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FirmId_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_FirmId_CodeMaster] FOREIGN KEY([FirmId])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FirmId_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_FirmId_CodeMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_CodeMaster] FOREIGN KEY([UnitID])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_CodeMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemMaster_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_ItemMaster] FOREIGN KEY([GroupID])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemMaster_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemMaster]'))
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_ItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTDetail]'))
ALTER TABLE [dbo].[KOTDetail]  WITH CHECK ADD  CONSTRAINT [FK_KOTDetail_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTDetail]'))
ALTER TABLE [dbo].[KOTDetail] CHECK CONSTRAINT [FK_KOTDetail_ItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTDetail_KOTMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTDetail]'))
ALTER TABLE [dbo].[KOTDetail]  WITH CHECK ADD  CONSTRAINT [FK_KOTDetail_KOTMaster] FOREIGN KEY([KOTID])
REFERENCES [dbo].[KOTMaster] ([KOTID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTDetail_KOTMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTDetail]'))
ALTER TABLE [dbo].[KOTDetail] CHECK CONSTRAINT [FK_KOTDetail_KOTMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTMaster]'))
ALTER TABLE [dbo].[KOTMaster]  WITH CHECK ADD  CONSTRAINT [FK_KOTMaster_CodeMaster] FOREIGN KEY([TableID])
REFERENCES [dbo].[CodeMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_KOTMaster_CodeMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[KOTMaster]'))
ALTER TABLE [dbo].[KOTMaster] CHECK CONSTRAINT [FK_KOTMaster_CodeMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseDetail]'))
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseDetail]'))
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_ItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseDetail_PurchaseMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseDetail]'))
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_PurchaseMaster] FOREIGN KEY([PurchaseID])
REFERENCES [dbo].[PurchaseMaster] ([PurchaseID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseDetail_PurchaseMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseDetail]'))
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_PurchaseMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseMaster_CompanyMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseMaster]'))
ALTER TABLE [dbo].[PurchaseMaster]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseMaster_CompanyMaster] FOREIGN KEY([VendorID])
REFERENCES [dbo].[CompanyMaster] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseMaster_CompanyMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseMaster]'))
ALTER TABLE [dbo].[PurchaseMaster] CHECK CONSTRAINT [FK_PurchaseMaster_CompanyMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseReturnDetail_PurchaseReturnDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseReturnDetail]'))
ALTER TABLE [dbo].[PurchaseReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnDetail_PurchaseReturnDetail] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseReturnDetail_PurchaseReturnDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseReturnDetail]'))
ALTER TABLE [dbo].[PurchaseReturnDetail] CHECK CONSTRAINT [FK_PurchaseReturnDetail_PurchaseReturnDetail]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseReturnDetail_PurchaseReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseReturnDetail]'))
ALTER TABLE [dbo].[PurchaseReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnDetail_PurchaseReturnMaster] FOREIGN KEY([PurchaseReturnMasterID])
REFERENCES [dbo].[PurchaseReturnMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PurchaseReturnDetail_PurchaseReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[PurchaseReturnDetail]'))
ALTER TABLE [dbo].[PurchaseReturnDetail] CHECK CONSTRAINT [FK_PurchaseReturnDetail_PurchaseReturnMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnDetail]'))
ALTER TABLE [dbo].[SalesReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturnDetail_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnDetail_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnDetail]'))
ALTER TABLE [dbo].[SalesReturnDetail] CHECK CONSTRAINT [FK_SalesReturnDetail_ItemMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnDetail_SalesReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnDetail]'))
ALTER TABLE [dbo].[SalesReturnDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturnDetail_SalesReturnMaster] FOREIGN KEY([SalesReturnMasterID])
REFERENCES [dbo].[SalesReturnMaster] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnDetail_SalesReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnDetail]'))
ALTER TABLE [dbo].[SalesReturnDetail] CHECK CONSTRAINT [FK_SalesReturnDetail_SalesReturnMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnMaster_SalesReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnMaster]'))
ALTER TABLE [dbo].[SalesReturnMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesReturnMaster_SalesReturnMaster] FOREIGN KEY([BillID])
REFERENCES [dbo].[BillMaster] ([BillID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SalesReturnMaster_SalesReturnMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[SalesReturnMaster]'))
ALTER TABLE [dbo].[SalesReturnMaster] CHECK CONSTRAINT [FK_SalesReturnMaster_SalesReturnMaster]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockBalance_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockBalance]'))
ALTER TABLE [dbo].[StockBalance]  WITH CHECK ADD  CONSTRAINT [FK_StockBalance_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StockBalance_ItemMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[StockBalance]'))
ALTER TABLE [dbo].[StockBalance] CHECK CONSTRAINT [FK_StockBalance_ItemMaster]
GO
