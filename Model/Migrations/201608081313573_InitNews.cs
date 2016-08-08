namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitNews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CW_Album", "CategoryID", "dbo.CW_Category");
            DropForeignKey("dbo.CW_AlbumImages", "AlbumID", "dbo.CW_Album");
            DropForeignKey("dbo.CW_Album", "LanguageCode", "dbo.CW_Language");
            DropForeignKey("dbo.CW_Category_UpdatePrice", "CategoryID", "dbo.CW_Category");
            DropForeignKey("dbo.CW_Category_UpdatePrice", "UpdatePriceID", "dbo.CW_UpdatePrice");
            DropForeignKey("dbo.CW_File", "CategoryID", "dbo.CW_Category");
            DropForeignKey("dbo.CW_File", "LanguageCode", "dbo.CW_Language");
            DropForeignKey("dbo.CW_Product", "CategoryID", "dbo.CW_Category");
            DropForeignKey("dbo.CW_FQAProduct", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_Product", "LanguageCode", "dbo.CW_Language");
            DropForeignKey("dbo.CW_Option_Rule_SetValue", "OptionRuleID", "dbo.CW_OptionRule");
            DropForeignKey("dbo.CW_Option_Rule_SetValue", "ProductOptionSetValueID", "dbo.CW_ProductOptionSetValue");
            DropForeignKey("dbo.CW_Product", "ProductOptionID", "dbo.CW_ProductOption");
            DropForeignKey("dbo.CW_Product_Option_OptionSet", "ProductOptionID", "dbo.CW_ProductOption");
            DropForeignKey("dbo.CW_Product_Option_OptionSet", "ProductOptionSetID", "dbo.CW_ProductOptionSet");
            DropForeignKey("dbo.CW_ProductOptionSetValue", "ProductOptionSetID", "dbo.CW_ProductOptionSet");
            DropForeignKey("dbo.CW_Option_Rule_Value", "OptionRuleID", "dbo.CW_OptionRule");
            DropForeignKey("dbo.CW_Option_Rule_Value", "OptionRuleValueID", "dbo.CW_OptionRuleValue");
            DropForeignKey("dbo.CW_OptionRule", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_Message", "UserId", "dbo.CW_Customers");
            DropForeignKey("dbo.CW_Order", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.CW_MessageReply", "MessageID", "dbo.CW_Message");
            DropForeignKey("dbo.CW_Message", "OrderID", "dbo.CW_Order");
            DropForeignKey("dbo.CW_OrderDetail", "OrderID", "dbo.CW_Order");
            DropForeignKey("dbo.CW_Order", "OrderStatusID", "dbo.CW_OrderStatus");
            DropForeignKey("dbo.CW_OrderDetail", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_ProductField", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_ProductImages", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_ProductTab", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_Reviews", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_Product", "VendorID", "dbo.CW_Vendor");
            DropForeignKey("dbo.CW_Wishlist", "ProductID", "dbo.CW_Product");
            DropForeignKey("dbo.CW_VideoClip", "CategoryID", "dbo.CW_Category");
            DropForeignKey("dbo.CW_VideoClip", "LanguageCode", "dbo.CW_Language");
            DropForeignKey("dbo.CW_OpinionAboutUs", "LanguageCode", "dbo.CW_Language");
            DropIndex("dbo.CW_Album", new[] { "CategoryID" });
            DropIndex("dbo.CW_Album", new[] { "LanguageCode" });
            DropIndex("dbo.CW_AlbumImages", new[] { "AlbumID" });
            DropIndex("dbo.CW_Category_UpdatePrice", new[] { "UpdatePriceID" });
            DropIndex("dbo.CW_Category_UpdatePrice", new[] { "CategoryID" });
            DropIndex("dbo.CW_File", new[] { "CategoryID" });
            DropIndex("dbo.CW_File", new[] { "LanguageCode" });
            DropIndex("dbo.CW_Product", new[] { "CategoryID" });
            DropIndex("dbo.CW_Product", new[] { "LanguageCode" });
            DropIndex("dbo.CW_Product", new[] { "VendorID" });
            DropIndex("dbo.CW_Product", new[] { "ProductOptionID" });
            DropIndex("dbo.CW_FQAProduct", new[] { "ProductID" });
            DropIndex("dbo.CW_OptionRule", new[] { "ProductID" });
            DropIndex("dbo.CW_Option_Rule_SetValue", new[] { "ProductOptionSetValueID" });
            DropIndex("dbo.CW_Option_Rule_SetValue", new[] { "OptionRuleID" });
            DropIndex("dbo.CW_ProductOptionSetValue", new[] { "ProductOptionSetID" });
            DropIndex("dbo.CW_Product_Option_OptionSet", new[] { "ProductOptionID" });
            DropIndex("dbo.CW_Product_Option_OptionSet", new[] { "ProductOptionSetID" });
            DropIndex("dbo.CW_Option_Rule_Value", new[] { "OptionRuleValueID" });
            DropIndex("dbo.CW_Option_Rule_Value", new[] { "OptionRuleID" });
            DropIndex("dbo.CW_OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.CW_OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.CW_Order", new[] { "UserId" });
            DropIndex("dbo.CW_Order", new[] { "OrderStatusID" });
            DropIndex("dbo.CW_Message", new[] { "OrderID" });
            DropIndex("dbo.CW_Message", new[] { "UserId" });
            DropIndex("dbo.CW_MessageReply", new[] { "MessageID" });
            DropIndex("dbo.CW_ProductField", new[] { "ProductID" });
            DropIndex("dbo.CW_ProductImages", new[] { "ProductID" });
            DropIndex("dbo.CW_ProductTab", new[] { "ProductID" });
            DropIndex("dbo.CW_Reviews", new[] { "ProductID" });
            DropIndex("dbo.CW_Wishlist", new[] { "ProductID" });
            DropIndex("dbo.CW_VideoClip", new[] { "CategoryID" });
            DropIndex("dbo.CW_VideoClip", new[] { "LanguageCode" });
            DropIndex("dbo.CW_OpinionAboutUs", new[] { "LanguageCode" });
            DropTable("dbo.CW_Album");
            DropTable("dbo.CW_AlbumImages");
            DropTable("dbo.CW_Category_UpdatePrice");
            DropTable("dbo.CW_UpdatePrice");
            DropTable("dbo.CW_File");
            DropTable("dbo.CW_Product");
            DropTable("dbo.CW_FQAProduct");
            DropTable("dbo.CW_OptionRule");
            DropTable("dbo.CW_Option_Rule_SetValue");
            DropTable("dbo.CW_ProductOptionSetValue");
            DropTable("dbo.CW_ProductOptionSet");
            DropTable("dbo.CW_Product_Option_OptionSet");
            DropTable("dbo.CW_ProductOption");
            DropTable("dbo.CW_Option_Rule_Value");
            DropTable("dbo.CW_OptionRuleValue");
            DropTable("dbo.CW_OrderDetail");
            DropTable("dbo.CW_Order");
            DropTable("dbo.CW_Message");
            DropTable("dbo.CW_MessageReply");
            DropTable("dbo.CW_OrderStatus");
            DropTable("dbo.CW_ProductField");
            DropTable("dbo.CW_ProductImages");
            DropTable("dbo.CW_ProductTab");
            DropTable("dbo.CW_Reviews");
            DropTable("dbo.CW_Vendor");
            DropTable("dbo.CW_Wishlist");
            DropTable("dbo.CW_VideoClip");
            DropTable("dbo.CW_OpinionAboutUs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CW_OpinionAboutUs",
                c => new
                    {
                        OpinionAboutUsID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        ByPost = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LanguageCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OpinionAboutUsID);
            
            CreateTable(
                "dbo.CW_VideoClip",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ClipName = c.String(nullable: false, maxLength: 300),
                        FilterTitle = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ClipLink = c.String(nullable: false, maxLength: 300),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        ClipSource = c.String(),
                        ClipImage = c.String(),
                        Description = c.String(),
                        ViewCount = c.Int(nullable: false),
                        Extentsion = c.String(),
                        TypeVideo = c.String(),
                        VideoSize = c.String(maxLength: 10),
                        LanguageCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.CW_Wishlist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CW_Vendor",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false, maxLength: 200),
                        FilterTitle = c.String(nullable: false, maxLength: 200),
                        Logo = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 12),
                        Address = c.String(maxLength: 300),
                        Email = c.String(maxLength: 100),
                        Description = c.String(maxLength: 300),
                        LanguageCode = c.String(maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendorID);
            
            CreateTable(
                "dbo.CW_Reviews",
                c => new
                    {
                        ReviewsID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        YourName = c.String(nullable: false, maxLength: 100),
                        YourReview = c.String(nullable: false, maxLength: 1000),
                        Rated = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewsID);
            
            CreateTable(
                "dbo.CW_ProductTab",
                c => new
                    {
                        ProductTabID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        TabName = c.String(nullable: false, maxLength: 100),
                        TabValue = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTabID);
            
            CreateTable(
                "dbo.CW_ProductImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Image = c.String(maxLength: 300),
                        Images = c.String(nullable: false, maxLength: 300),
                        IsDefault = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CW_ProductField",
                c => new
                    {
                        FieldID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        FieldName = c.String(nullable: false, maxLength: 100),
                        FieldValue = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FieldID);
            
            CreateTable(
                "dbo.CW_OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        OrderStatus = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.CW_MessageReply",
                c => new
                    {
                        ReplyMessageID = c.Int(nullable: false, identity: true),
                        MessageID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyMessageID);
            
            CreateTable(
                "dbo.CW_Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        IsShowed = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.CW_Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderCode = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(),
                        FullnameOrder = c.String(nullable: false, maxLength: 100),
                        SexOrder = c.Boolean(nullable: false),
                        AddressOrder = c.String(maxLength: 200),
                        EmailOrder = c.String(nullable: false, maxLength: 100),
                        PhoneOrder = c.String(nullable: false, maxLength: 12),
                        OtherInfoOrder = c.String(maxLength: 300),
                        FullnameReceived = c.String(maxLength: 100),
                        SexReceived = c.Boolean(nullable: false),
                        AddressReceived = c.String(maxLength: 200),
                        EmailReceived = c.String(maxLength: 100),
                        PhoneReceived = c.String(maxLength: 12),
                        OtherInfoReceived = c.String(maxLength: 300),
                        Shipping = c.Int(nullable: false),
                        TransitTime = c.String(maxLength: 200),
                        Payment = c.Int(nullable: false),
                        TotalPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductNumber = c.Int(nullable: false),
                        OrderStatusID = c.Int(nullable: false),
                        OnOrder = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.CW_OrderDetail",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID });
            
            CreateTable(
                "dbo.CW_OptionRuleValue",
                c => new
                    {
                        OptionRuleValueID = c.Int(nullable: false, identity: true),
                        OptionRuleValue = c.String(nullable: false, maxLength: 100),
                        OptionRuleType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OptionRuleValueID);
            
            CreateTable(
                "dbo.CW_Option_Rule_Value",
                c => new
                    {
                        OptionRuleValueID = c.Int(nullable: false),
                        OptionRuleID = c.Int(nullable: false),
                        SaveOptionRuleValue = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.OptionRuleValueID, t.OptionRuleID });
            
            CreateTable(
                "dbo.CW_ProductOption",
                c => new
                    {
                        ProductOptionID = c.Int(nullable: false, identity: true),
                        ProductOptionName = c.String(nullable: false, maxLength: 200),
                        LanguageCode = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOptionID);
            
            CreateTable(
                "dbo.CW_Product_Option_OptionSet",
                c => new
                    {
                        ProductOptionID = c.Int(nullable: false),
                        ProductOptionSetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductOptionID, t.ProductOptionSetID });
            
            CreateTable(
                "dbo.CW_ProductOptionSet",
                c => new
                    {
                        ProductOptionSetID = c.Int(nullable: false, identity: true),
                        ProductOptionSetName = c.String(nullable: false, maxLength: 200),
                        Datatype = c.Short(nullable: false),
                        DisplayType = c.Short(),
                        LanguageCode = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOptionSetID);
            
            CreateTable(
                "dbo.CW_ProductOptionSetValue",
                c => new
                    {
                        ProductOptionSetValueID = c.Int(nullable: false, identity: true),
                        ProductOptionSetID = c.Int(nullable: false),
                        ProductOptionSetValueName = c.String(nullable: false, maxLength: 200),
                        ProductOptionSetType = c.Short(),
                        ProductOptionSetValue = c.String(nullable: false, maxLength: 200),
                        LanguageCode = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOptionSetValueID);
            
            CreateTable(
                "dbo.CW_Option_Rule_SetValue",
                c => new
                    {
                        ProductOptionSetValueID = c.Int(nullable: false),
                        OptionRuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductOptionSetValueID, t.OptionRuleID });
            
            CreateTable(
                "dbo.CW_OptionRule",
                c => new
                    {
                        OptionRuleID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        IsUse = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OptionRuleID);
            
            CreateTable(
                "dbo.CW_FQAProduct",
                c => new
                    {
                        FQAID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Question = c.String(nullable: false, maxLength: 300),
                        Answer = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        QuestionDate = c.DateTime(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                        SearchKey = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.FQAID);
            
            CreateTable(
                "dbo.CW_Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        FilterTitle = c.String(nullable: false),
                        ProductCode = c.String(maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSaleOff = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 3000),
                        Content = c.String(),
                        ViewCount = c.Int(nullable: false),
                        ImageHover = c.String(maxLength: 300),
                        CreatedBy = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 20),
                        ModifiedDate = c.DateTime(nullable: false),
                        Tag = c.String(),
                        Metatitle = c.String(maxLength: 200),
                        MetaKeywords = c.String(maxLength: 200),
                        MetaDescription = c.String(maxLength: 300),
                        IsActive = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        IsPromotion = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        IsAllowPurchase = c.String(maxLength: 20),
                        CallForPricingLabel = c.String(maxLength: 50),
                        LanguageCode = c.String(maxLength: 128),
                        ProductRelateID = c.String(maxLength: 100),
                        KeySearch = c.String(),
                        VendorID = c.Int(),
                        ProductOptionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.CW_File",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        FilterTitle = c.String(nullable: false),
                        PathFile = c.String(nullable: false, maxLength: 300),
                        Images = c.String(maxLength: 300),
                        Description = c.String(maxLength: 1000),
                        Content = c.String(),
                        CountDownload = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        LanguageCode = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CW_UpdatePrice",
                c => new
                    {
                        UpdatePriceID = c.Int(nullable: false, identity: true),
                        UpdatePriceType = c.Int(nullable: false),
                        Kind = c.String(),
                        PriceNew = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UpdatePriceID);
            
            CreateTable(
                "dbo.CW_Category_UpdatePrice",
                c => new
                    {
                        UpdatePriceID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UpdatePriceID, t.CategoryID });
            
            CreateTable(
                "dbo.CW_AlbumImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        Image = c.String(maxLength: 200),
                        Images = c.String(nullable: false, maxLength: 200),
                        IsDefault = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CW_Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(nullable: false, maxLength: 300),
                        FilterTitle = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 300),
                        LanguageCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AlbumID);
            
            CreateIndex("dbo.CW_OpinionAboutUs", "LanguageCode");
            CreateIndex("dbo.CW_VideoClip", "LanguageCode");
            CreateIndex("dbo.CW_VideoClip", "CategoryID");
            CreateIndex("dbo.CW_Wishlist", "ProductID");
            CreateIndex("dbo.CW_Reviews", "ProductID");
            CreateIndex("dbo.CW_ProductTab", "ProductID");
            CreateIndex("dbo.CW_ProductImages", "ProductID");
            CreateIndex("dbo.CW_ProductField", "ProductID");
            CreateIndex("dbo.CW_MessageReply", "MessageID");
            CreateIndex("dbo.CW_Message", "UserId");
            CreateIndex("dbo.CW_Message", "OrderID");
            CreateIndex("dbo.CW_Order", "OrderStatusID");
            CreateIndex("dbo.CW_Order", "UserId");
            CreateIndex("dbo.CW_OrderDetail", "ProductID");
            CreateIndex("dbo.CW_OrderDetail", "OrderID");
            CreateIndex("dbo.CW_Option_Rule_Value", "OptionRuleID");
            CreateIndex("dbo.CW_Option_Rule_Value", "OptionRuleValueID");
            CreateIndex("dbo.CW_Product_Option_OptionSet", "ProductOptionSetID");
            CreateIndex("dbo.CW_Product_Option_OptionSet", "ProductOptionID");
            CreateIndex("dbo.CW_ProductOptionSetValue", "ProductOptionSetID");
            CreateIndex("dbo.CW_Option_Rule_SetValue", "OptionRuleID");
            CreateIndex("dbo.CW_Option_Rule_SetValue", "ProductOptionSetValueID");
            CreateIndex("dbo.CW_OptionRule", "ProductID");
            CreateIndex("dbo.CW_FQAProduct", "ProductID");
            CreateIndex("dbo.CW_Product", "ProductOptionID");
            CreateIndex("dbo.CW_Product", "VendorID");
            CreateIndex("dbo.CW_Product", "LanguageCode");
            CreateIndex("dbo.CW_Product", "CategoryID");
            CreateIndex("dbo.CW_File", "LanguageCode");
            CreateIndex("dbo.CW_File", "CategoryID");
            CreateIndex("dbo.CW_Category_UpdatePrice", "CategoryID");
            CreateIndex("dbo.CW_Category_UpdatePrice", "UpdatePriceID");
            CreateIndex("dbo.CW_AlbumImages", "AlbumID");
            CreateIndex("dbo.CW_Album", "LanguageCode");
            CreateIndex("dbo.CW_Album", "CategoryID");
            AddForeignKey("dbo.CW_OpinionAboutUs", "LanguageCode", "dbo.CW_Language", "LanguageCode");
            AddForeignKey("dbo.CW_VideoClip", "LanguageCode", "dbo.CW_Language", "LanguageCode");
            AddForeignKey("dbo.CW_VideoClip", "CategoryID", "dbo.CW_Category", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Wishlist", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product", "VendorID", "dbo.CW_Vendor", "VendorID");
            AddForeignKey("dbo.CW_Reviews", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_ProductTab", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_ProductImages", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_ProductField", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_OrderDetail", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Order", "OrderStatusID", "dbo.CW_OrderStatus", "OrderStatusID", cascadeDelete: true);
            AddForeignKey("dbo.CW_OrderDetail", "OrderID", "dbo.CW_Order", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Message", "OrderID", "dbo.CW_Order", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.CW_MessageReply", "MessageID", "dbo.CW_Message", "MessageID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Order", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.CW_Message", "UserId", "dbo.CW_Customers", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.CW_OptionRule", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Option_Rule_Value", "OptionRuleValueID", "dbo.CW_OptionRuleValue", "OptionRuleValueID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Option_Rule_Value", "OptionRuleID", "dbo.CW_OptionRule", "OptionRuleID", cascadeDelete: true);
            AddForeignKey("dbo.CW_ProductOptionSetValue", "ProductOptionSetID", "dbo.CW_ProductOptionSet", "ProductOptionSetID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product_Option_OptionSet", "ProductOptionSetID", "dbo.CW_ProductOptionSet", "ProductOptionSetID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product_Option_OptionSet", "ProductOptionID", "dbo.CW_ProductOption", "ProductOptionID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product", "ProductOptionID", "dbo.CW_ProductOption", "ProductOptionID");
            AddForeignKey("dbo.CW_Option_Rule_SetValue", "ProductOptionSetValueID", "dbo.CW_ProductOptionSetValue", "ProductOptionSetValueID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Option_Rule_SetValue", "OptionRuleID", "dbo.CW_OptionRule", "OptionRuleID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product", "LanguageCode", "dbo.CW_Language", "LanguageCode");
            AddForeignKey("dbo.CW_FQAProduct", "ProductID", "dbo.CW_Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Product", "CategoryID", "dbo.CW_Category", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CW_File", "LanguageCode", "dbo.CW_Language", "LanguageCode");
            AddForeignKey("dbo.CW_File", "CategoryID", "dbo.CW_Category", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Category_UpdatePrice", "UpdatePriceID", "dbo.CW_UpdatePrice", "UpdatePriceID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Category_UpdatePrice", "CategoryID", "dbo.CW_Category", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Album", "LanguageCode", "dbo.CW_Language", "LanguageCode");
            AddForeignKey("dbo.CW_AlbumImages", "AlbumID", "dbo.CW_Album", "AlbumID", cascadeDelete: true);
            AddForeignKey("dbo.CW_Album", "CategoryID", "dbo.CW_Category", "ID", cascadeDelete: true);
        }
    }
}
