/****** Object:  View [bi].[Customer]    Script Date: 2/8/2023 9:36:11 PM ******/
CREATE SCHEMA [bi]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [bi].[Customer]
AS
SELECT 
  M.Id as CustomerId, 
  M.CreatedDate, 
  M.Name, 
  M.FirstName, 
  M.MiddleName, 
  M.LastName, 
  M.FullName, 
  M.Status, 
  A.StoreId 
FROM 
  dbo.Member AS M 
  INNER JOIN dbo.AspNetUsers AS A ON M.Id = A.Id 
WHERE 
  (
    M.Discriminator = 'ContactEntity'
  )

GO
/****** Object:  View [bi].[Orders]    Script Date: 2/8/2023 9:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [bi].[Orders]
AS
SELECT 
  Id as OrderId, 
  CreatedDate, 
  Number AS OrderNumber, 
  Status, 
  SubTotal, 
  ShippingTotal, 
  TaxTotal, 
  PaymentTotal, 
  FeeTotal, 
  DiscountTotal, 
  Total, 
  Currency, 
  SubTotal + ShippingTotal + TaxTotal + PaymentTotal + FeeTotal - DiscountTotal AS CalculatedTotal, 
  CustomerId, 
  StoreId, 
  OrganizationId 
FROM 
  dbo.CustomerOrder

GO
/****** Object:  View [bi].[Organization]    Script Date: 2/8/2023 9:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [bi].[Organization]
AS
SELECT 
  Id As OrganizationId, 
  CreatedDate, 
  Name, 
  Status 
FROM 
  dbo.Member AS M 
WHERE 
  (
    Discriminator = 'OrganizationEntity'
  )

GO
/****** Object:  View [bi].[Product]    Script Date: 2/8/2023 9:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [bi].[Product]
AS
SELECT 
  dbo.Item.Code AS Sku, 
  dbo.Item.Name, 
  dbo.Item.Id, 
  dbo.Item.ProductType, 
  dbo.Category.Name AS Category, 
  dbo.Category.Id AS CategoryId, 
  (
    SELECT 
      TOP (1) Url 
    FROM 
      dbo.CatalogImage 
    WHERE 
      (ItemId = dbo.Item.Id) 
    ORDER BY 
      SortOrder
  ) AS ProductImage, 
  (
    SELECT 
      TOP (1) Url 
    FROM 
      dbo.CatalogImage 
    WHERE 
      (CategoryId = dbo.Category.Id) 
    ORDER BY 
      SortOrder
  ) AS CategoryImage 
FROM 
  dbo.Item 
  INNER JOIN dbo.Category ON dbo.Item.CategoryId = dbo.Category.Id

GO
/****** Object:  View [bi].[Sales]    Script Date: 2/8/2023 9:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [bi].[Sales]
AS
SELECT 
  dbo.OrderLineItem.Id as SaleId, 
  dbo.OrderLineItem.CreatedDate, 
  dbo.OrderLineItem.Currency, 
  dbo.OrderLineItem.Price, 
  dbo.OrderLineItem.DiscountAmount, 
  (
    dbo.OrderLineItem.Price - dbo.OrderLineItem.DiscountAmount
  )* dbo.OrderLineItem.Quantity AS Amount, 
  dbo.OrderLineItem.Quantity, 
  dbo.OrderLineItem.Sku, 
  dbo.CustomerOrder.Number AS OrderNumber, 
  dbo.CustomerOrder.Number AS OrderId, 
  dbo.CustomerOrder.CustomerId, 
  dbo.CustomerOrder.StoreId, 
  dbo.CustomerOrder.OrganizationId, 
  dbo.CustomerOrder.Status 
FROM 
  dbo.OrderLineItem 
  INNER JOIN dbo.CustomerOrder ON dbo.OrderLineItem.CustomerOrderId = dbo.CustomerOrder.Id

GO
/****** Object:  View [bi].[Store]    Script Date: 2/8/2023 9:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [bi].[Store]
AS
SELECT 
  Id as StoreId, 
  Name, 
  Description, 
  Url, 
  StoreState, 
  TimeZone, 
  Country, 
  Region, 
  DefaultLanguage, 
  DefaultCurrency 
FROM 
  dbo.Store

GO
