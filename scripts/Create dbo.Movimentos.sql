USE [MovimentosManuais]
GO

/****** Object: Table [dbo].[Movimentos] Script Date: 01/03/2019 09:36:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movimentos] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [DataMes]             INT            NOT NULL,
    [DataAno]             INT            NOT NULL,
    [NumeroLancamento]    INT            NOT NULL,
    [CodigoProduto]       NVARCHAR (MAX) NULL,
    [CodigoCosif]         NVARCHAR (MAX) NULL,
    [ValorMovimento]      INT            NOT NULL,
    [DescricaoLancamento] NVARCHAR (MAX) NULL,
    [DataMovimentacaq]    DATETIME2 (7)  NOT NULL,
    [CodigoUsuario]       NVARCHAR (MAX) NULL
);


