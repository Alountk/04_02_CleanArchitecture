IF NOT EXISTS (
    SELECT *
    FROM sys.schemas t1
    WHERE (t1.name = N'Sample')
) EXEC('CREATE SCHEMA [Sample] AUTHORIZATION [dbo];');