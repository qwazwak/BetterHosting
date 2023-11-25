BEGIN TRANSACTION;

--CREATE TABLE [Guilds] (
--  [GuildID] bigint NOT NULL
--, CONSTRAINT [sqlite_master_PK_Guilds] PRIMARY KEY ([GuildID])
--);

CREATE TABLE [SwearJars] (
  [GuildID] bigint NOT NULL
, [ValueOfSingleSwear] real NOT NULL
, [SwearCount] bigint NOT NULL
, CONSTRAINT [sqlite_autoindex_SwearJars_1] PRIMARY KEY ([GuildID])
--, FOREIGN KEY ([GuildID]) REFERENCES [Guilds] ([GuildID])
);

COMMIT;