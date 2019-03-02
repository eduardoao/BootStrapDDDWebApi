USE [MovimentosManuais]
GO

/****** Object: SqlProcedure [dbo].[SpMovimentacao] Script Date: 01/03/2019 09:36:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SpMovimentacao

AS
	SELECT 
		DataAno
		,DataMes
		,CodigoProduto
		,Produtos.Descricao
		,NumeroLancamento
		FROM 
			Movimentos INNER JOIN Produtos
			ON Movimentos.CodigoProduto = Produtos.Id
