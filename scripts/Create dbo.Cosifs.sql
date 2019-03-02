USE [MovimentosManuais]
GO

/****** Object: Table [dbo].[Cosifs] Script Date: 01/03/2019 09:35:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cosifs] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [CodigoProduto]       NVARCHAR (MAX) NULL,
    [CodigoClassificacao] NVARCHAR (MAX) NULL,
    [Classificacao]       INT            NULL,
    [StatusCosif]         INT            NULL,
    [MovimentoId]         INT            NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Cosifs_MovimentoId]
    ON [dbo].[Cosifs]([MovimentoId] ASC);


GO
ALTER TABLE [dbo].[Cosifs]
    ADD CONSTRAINT [PK_Cosifs] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[Cosifs]
    ADD CONSTRAINT [FK_Cosifs_Movimentos_MovimentoId] FOREIGN KEY ([MovimentoId]) REFERENCES [dbo].[Movimentos] ([Id]) ON DELETE CASCADE;


