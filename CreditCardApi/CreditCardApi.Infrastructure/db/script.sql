CREATE DATABASE CreditCardDb;

CREATE TYPE dbo.TransactionTableType AS TABLE
(
    Id UNIQUEIDENTIFIER,
    CreditCardID UNIQUEIDENTIFIER,
    Concept NVARCHAR(MAX),
    TransactionType INT,
    TransactionDate DATETIME,
    Amount MONEY
);

USE [CreditCardDb]
GO

/****** Objeto: SqlProcedure [dbo].[InsertCreditCardTransaction] Fecha del script: 18/04/2024 01:37:11 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE InsertCreditCardTransaction
    @Transaction TransactionTableType READONLY
AS
BEGIN
    BEGIN TRY

         INSERT INTO CreditCardTransactions (Id, CreditCardID, Concept, TransactionType, TransactionDate, Amount, CreatedAt)
        SELECT Id, CreditCardID, Concept, TransactionType, TransactionDate, Amount, GETDATE()
        FROM @Transaction;

		UPDATE CDD SET 
		Currentbalance = CASE 
							WHEN TransactionType = 0 THEN Currentbalance + Amount
							WHEN TransactionType = 1 THEN Currentbalance - Amount
						END
		FROM CreditCardDetails CDD 
		INNER JOIN @Transaction T ON T.CreditCardID = CDD.CreditCarID
    END TRY
    BEGIN CATCH

        DECLARE @ErrorMessage NVARCHAR(MAX);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);

    END CATCH
END;