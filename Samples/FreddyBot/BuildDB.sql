--CREATE TABLE [Guilds] (
--  [GuildID] BigInt NOT NULL UNIQUE
--);

CREATE TABLE [SwearJars] (
  [GuildID] BigInt NOT NULL
, [ValueOfSingleSwear] REAL NOT NULL
, [SwearCount] INTEGER NOT NULL
, CONSTRAINT [PK_SwearJars] PRIMARY KEY ([GuildID])
--, FOREIGN KEY(GuildID) REFERENCES Guilds(GuildID)
);