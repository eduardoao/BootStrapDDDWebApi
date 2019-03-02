USE [MovimentosManuais]
GO

/****** Object: Table [dbo].[Produtos] Script Date: 01/03/2019 09:36:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Descricao]     NVARCHAR (30) NULL,
    [StatusProduto] INT           NULL,
    [CosifId]       INT           NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Produtos_CosifId]
    ON [dbo].[Produtos]([CosifId] ASC);


GO
ALTER TABLE [dbo].[Produtos]
    ADD CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Produtos]
    ADD CONSTRAINT [FK_Produtos_Cosifs_CosifId] FOREIGN KEY ([CosifId]) REFERENCES [dbo].[Cosifs] ([Id]);


