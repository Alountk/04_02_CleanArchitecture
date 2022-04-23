CREATE TABLE blog.Users (
    id uuid DEFAULT uuid_generate_v4 (),
    first_name varchar(50) NULL DEFAULT NULL,
    last_name varchar(50) NULL DEFAULT NULL,
    email varchar(50) NOT NULL,
    username varchar(50) NOT NULL,
    password_hash varchar(32) NOT NULL,
    is_admin bool NOT NULL,
    is_active bool NOT NULL,
    registered_at timestamp NOT NULL DEFAULT NOW(),
    updated_at timestamp NOT NULL DEFAULT NOW(),
    last_login TIMESTAMP null default null,
    CONSTRAINT PK_blogUsers PRIMARY KEY (id),
    CONSTRAINT UQ_blogUsers UNIQUE (id),
    CONSTRAINT UQ_blogUsers_email UNIQUE (email)
);
-- CREATE TABLE blog.Posts (
--     id uuid DEFAULT uuid_generate_v4 (),
--     author_id BIGINT(20) NOT NULL,
--     parent_id BIGINT(20) NULL DEFAULT NULL,
--     title varchar(75) NOT NULL,
--     meta_title varchar(100) NULL,
--     slug varchar(100) NOT NULL,
--     summary TINYTEXT NULL,
--     published TINYINT(1) NOT NULL DEFAULT 0,
--     deleted bool NOT NULL DEFAULT false,
--     owner_id smallserial NOT NULL,
--     created_at timestamp NOT NULL DEFAULT NOW(),
--     updated_at timestamp NOT NULL DEFAULT NOW(),
--     published_at timestamp NOT NULL DEFAULT NOW(),
--     content LONGTEXT NULL DEFAULT NULL,
--     CONSTRAINT PK_blogPosts PRIMARY KEY (id),
--     CONSTRAINT UQ_blogPosts UNIQUE (id),
--     CONSTRAINT FK_blogPosts_author_id FOREIGN KEY (author_id) REFERENCES blog.Users (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
-- );
-- ALTER TABLE blog.Posts
-- ADD INDEX 'idx_post_parent' (parent_id);
-- ALTER TABLE blog.Posts
-- ADD CONSTRAINT 'fk_post_parent' FOREIGN KEY (parent_id) REFERENCES blog.Posts (id) ON DELETE NO ACTION ON UPDATE NO ACTION;
-- CREATE TABLE blog.PostMetas (
--     id uuid DEFAULT uuid_generate_v4 (),
--     post_id BIGINT(20) NOT NULL,
--     meta_key varchar(100) NOT NULL,
--     meta_value LONGTEXT NULL DEFAULT NULL,
--     CONSTRAINT PK_blogPostMeta PRIMARY KEY (id),
--     CONSTRAINT UQ_blogPostMeta UNIQUE (id),
--     CONSTRAINT FK_blogPostMeta_post FOREIGN KEY (post_id) REFERENCES blog.Posts (id) ON DELETE NO ACTION ON UPDATE NO ACTION
-- );
-- CREATE TABLE blog.PostComments (
--     id uuid DEFAULT uuid_generate_v4 (),
--     post_id BIGINT(20) NOT NULL,
--     parent_id BIGINT(20) NOT NULL,
--     title VARCHAR(100) NOT NULL,
--     published TINYINT(1) NOT NULL DEFAULT 0,
--     created_at timestamp NOT NULL DEFAULT NOW(),
--     published_at timestamp NOT NULL DEFAULT NOW(),
--     content LONGTEXT NULL DEFAULT NULL,
--     CONSTRAINT PK_blogPostComments PRIMARY KEY (id),
--     CONSTRAINT UQ_blogPostComments UNIQUE (id),
--     CONSTRAINT FK_blogPostComments_post FOREIGN KEY (post_id) REFERENCES blog.Posts (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
--     CONSTRAINT FK_blogPostComments_author FOREIGN KEY (author_id) REFERENCES blog.Users (id) ON DELETE NO ACTION ON UPDATE NO ACTION
-- );
-- ALTER TABLE blog.PostComments
-- ADD INDEX 'idx_comment_parent' (parent_id);
-- ALTER TABLE blog.PostComments
-- ADD CONSTRAINT 'fk_comment_parent' FOREIGN KEY (parent_id) REFERENCES blog.PostComments (id) ON DELETE NO ACTION ON UPDATE NO ACTION;
-- CREATE TABLE blog.Categories (
--     id uuid DEFAULT uuid_generate_v4 (),
--     parent_id BIGINT(20) NULL DEFAULT NULL,
--     title varchar(100) NOT NULL,
--     meta_title varchar(100) NULL,
--     slug varchar(100) NOT NULL,
--     content LONGTEXT NULL DEFAULT NULL,
--     CONSTRAINT PK_blogCategory PRIMARY KEY (id),
--     CONSTRAINT UQ_blogCategory UNIQUE (id)
-- );
-- ALTER TABLE blog.Categories
-- ADD INDEX 'idx_category_parent' (parent_id);
-- ALTER TABLE blog.Categories
-- ADD CONSTRAINT 'fk_category_parent' FOREIGN KEY (parent_id) REFERENCES blog.Categories (id) ON DELETE NO ACTION ON UPDATE NO ACTION;
-- CREATE TABLE blog.PostCategories (
--     id uuid DEFAULT uuid_generate_v4 (),
--     category_id BIGINT(20) NOT NULL,
--     CONSTRAINT PK_blogPostCategory PRIMARY KEY (id),
--     CONSTRAINT UQ_blogPostCategory UNIQUE (id),
--     CONSTRAINT FK_blogPostCategory_post FOREIGN KEY (post_id) REFERENCES blog.Posts (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
--     CONSTRAINT FK_blogPostCategory_category FOREIGN KEY (category_id) REFERENCES blog.Categories (id) ON DELETE NO ACTION ON UPDATE NO ACTION
-- );