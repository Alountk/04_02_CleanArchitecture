-- 1. Create account admin
INSERT INTO blog.users (
        first_name,
        last_name,
        email,
        username,
        password_hash,
        is_admin,
        is_active,
        registered_at,
        updated_at,
        last_login
    )
VALUES (
        'admin',
        'admin',
        'admin@admin.com',
        'root',
        'password_hash',
        true,
        true,
        current_timestamp,
        current_timestamp,
        current_timestamp
    )