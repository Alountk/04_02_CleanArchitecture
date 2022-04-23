IF OBJECT_ID('dbo.blogUsers') IS NOT NULL BEGIN DROP TABLE dbo.blogUsers;
IF OBJECT_ID('dbo.blogUsers') IS NOT NULL RAISERROR(
    '[dbo].[blogUsers] table could not be dropped',
    16,
    1
);
PRINT '<<< [dbo].[blogUsers] table could not be dropped >>>';
END IF;
ELSE PRINT '<<< [dbo].[blogUsers] table dropped >>>';
END IF;
END;
CREATE TABLE dbo.blogUsers (
    [account_id] [int] IDENTITY(1, 1) NOT NULL,
    [first_name] [varchar](255) NOT NULL,
    [last_name] [varchar](255) NOT NULL,
    [email] [varchar](255) NOT NULL,
    [username] [varchar](255) NOT NULL,
    [passwordhash] [varchar](255) NOT NULL,
    [salt] [varchar](255) NOT NULL,
    [IsAdmin] [bit] NOT NULL,
    [IsActive] [bit] NOT NULL,
    [created_at] [datetime] NOT NULL,
    [updated_at] [datetime] NOT NULL,
    [deleted_at] [datetime] NULL,
    CONSTRAINT [PK_blogUsers] PRIMARY KEY CLUSTERED ([account_id] ASC) CONSTRAINT [UQ_blogUsers] UNIQUE NONCLUSTERED ([account_id] ASC) CONSTRAINT [UQ_blogUsers_email] UNIQUE NONCLUSTERED ([email] ASC)
)
GO IF OBJECT_ID('dbo.blogUsers') IS NOT NULL PRINT '<<< [dbo].[blogUsers] table created >>>';
ELSE PRINT '<<< [dbo].[blogUsers] table could not be created >>>';
END;