CREATE TABLE blog.users (
    id uuid DEFAULT uuid_generate_v4 (),
    first_name varchar(50) NULL DEFAULT NULL,
    last_name varchar(50) NULL DEFAULT NULL,
    email varchar(50) NOT NULL,
    username varchar(50) NOT NULL,
    password_hash varchar(32) NOT NULL,
    password_salt varchar(32) NOT NULL,
    is_admin bool NOT NULL,
    is_active bool NOT NULL,
    registered_at timestamp NOT NULL DEFAULT NOW(),
    updated_at timestamp NOT NULL DEFAULT NOW(),
    last_login TIMESTAMP null default null,
    CONSTRAINT PK_blogUsers PRIMARY KEY (id),
    CONSTRAINT UQ_blogUsers UNIQUE (id),
    CONSTRAINT UQ_blogUsers_email UNIQUE (email)
);
CREATE TABLE blog.posts (
    id uuid DEFAULT uuid_generate_v4 (),
    author_id uuid NOT NULL,
    parent_id uuid NULL DEFAULT NULL,
    title varchar(75) NOT NULL,
    meta_title varchar(100) NULL,
    slug varchar(100) NOT NULL,
    summary TEXT NULL,
    published bool NOT NULL DEFAULT false,
    deleted bool NOT NULL DEFAULT false,
    created_at timestamp NOT NULL DEFAULT NOW(),
    updated_at timestamp NOT NULL DEFAULT NOW(),
    published_at timestamp NOT NULL DEFAULT NOW(),
    content TEXT NULL DEFAULT NULL,
    CONSTRAINT PK_blogPosts PRIMARY KEY (id),
    CONSTRAINT UQ_blogPosts UNIQUE (id)
);
CREATE TABLE blog.post_metas (
    id uuid DEFAULT uuid_generate_v4 (),
    post_id uuid NOT NULL,
    meta_key varchar(100) NOT NULL,
    meta_value TEXT NULL DEFAULT NULL,
    CONSTRAINT PK_blogPostMeta PRIMARY KEY (id),
    CONSTRAINT UQ_blogPostMeta UNIQUE (id)
);
CREATE TABLE blog.post_comments (
    id uuid DEFAULT uuid_generate_v4 (),
    post_id uuid NOT NULL,
    parent_id uuid NOT NULL,
    title VARCHAR(100) NOT NULL,
    published bool NOT NULL DEFAULT false,
    created_at timestamp NOT NULL DEFAULT NOW(),
    published_at timestamp NOT NULL DEFAULT NOW(),
    content TEXT NULL DEFAULT NULL,
    CONSTRAINT PK_blogPostComments PRIMARY KEY (id),
    CONSTRAINT UQ_blogPostComments UNIQUE (id)
);
CREATE TABLE blog.categories (
    id uuid DEFAULT uuid_generate_v4 (),
    parent_id uuid NULL DEFAULT NULL,
    title varchar(100) NOT NULL,
    meta_title varchar(100) NULL,
    slug varchar(100) NOT NULL,
    content TEXT NULL DEFAULT NULL,
    CONSTRAINT PK_blogCategory PRIMARY KEY (id),
    CONSTRAINT UQ_blogCategory UNIQUE (id)
);
CREATE TABLE blog.post_categories (
    id uuid DEFAULT uuid_generate_v4 (),
    category_id uuid NOT NULL,
    CONSTRAINT PK_blogPostCategory PRIMARY KEY (id),
    CONSTRAINT UQ_blogPostCategory UNIQUE (id)
);
-- ALTER TABLE blog.posts
-- ADD INDEX 'idx_post_parent' (parent_id);
-- ALTER TABLE blog.posts
-- ADD CONSTRAINT 'fk_post_parent' FOREIGN KEY (parent_id) REFERENCES blog.posts (id) ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ALTER TABLE blog.post_comments
-- ADD INDEX 'idx_comment_parent' (parent_id);
-- ALTER TABLE blog.post_comments
-- ADD CONSTRAINT 'fk_comment_parent' FOREIGN KEY (parent_id) REFERENCES blog.post_comments (id) ON DELETE NO ACTION ON UPDATE NO ACTION;
-- ALTER TABLE blog.categories
-- ADD INDEX 'idx_category_parent' (parent_id);
-- ALTER TABLE blog.categories
-- ADD CONSTRAINT 'fk_category_parent' FOREIGN KEY (parent_id) REFERENCES blog.categories (id) ON DELETE NO ACTION ON UPDATE NO ACTION;