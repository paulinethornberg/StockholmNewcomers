
CREATE TABLE [dbo].[tags_categoryTags] (
    -- Can have your own surrogate if you want
    [Id]      INT IDENTITY(1,1) NOT NULL,
    OrganizationId INT NOT NULL,
    TagsId INT NOT NULL,

    -- Referential Integrity
    FOREIGN KEY(OrganizationId) REFERENCES organizations(Id),
    FOREIGN KEY(TagsId) REFERENCES tags(Id),

    -- PK can be own surrogate, or the composite (AuthorId, BookId)
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


