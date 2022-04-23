-- 1. Create account admin
INSERT INTO [dbo.blogUsers] (
        [first_name],
        [last_name],
        [email],
        [username],
        [passwordhash],
        [salt],
        [IsAdmin],
        [IsActive],
        [created_at],
        [updated_at],
        [deleted_at]
    )
VALUES (
        'admin',
        'admin',
        'root',
        'admin@admin.com',
        'root',
        'root',
        1,
        1,
        getutcdate(),
        getutcdate(),
        null,