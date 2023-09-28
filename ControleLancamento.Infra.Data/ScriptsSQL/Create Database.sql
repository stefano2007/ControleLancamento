Create database dbControleLancamento;
go
Use dbControleLancamento;
GO

Create Table tbCategoryType(
  Id int not null identity(1, 1) primary key,
  nmCategoryType   varchar(100) not null,
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go

Create Table tbCategory(
  Id int not null identity(1, 1) primary key,
  categoryTypeId int not null FOREIGN KEY REFERENCES tbCategoryType(Id),
  nmCategory   varchar(100) not null,
  Color        varchar(7),
  Icon         varchar(20),
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go

Create Table tbAccountType(
  Id int not null identity(1, 1) primary key,
  nmAccountType   varchar(100) not null,
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go
Create Table tbUser(
  Id int not null identity(1, 1) primary key,
  nmUser       varchar(100) not null,
  email        varchar(120) not null,
  password     varchar(60) not null,
  occupation   varchar(60),
  cellPhone    varchar(11),
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go


Create Table tbAccount(
  Id int not null identity(1, 1) primary key,
  AccountTypeId int not null FOREIGN KEY REFERENCES tbAccountType(Id),
  nmAccount   varchar(100) not null,
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go

Create Table tbUserAccount(
  Id int not null identity(1, 1) primary key,
  userId    int not null FOREIGN KEY REFERENCES tbUser(Id),
  accountId int not null FOREIGN KEY REFERENCES tbAccount(Id),
  isUserMain    bit not null default 0,
  ckActive  bit not null default 1,
  dtCreate  Datetime  not null default getdate(),
)
--permitido que uma conta tenha apenas um principal
CREATE UNIQUE INDEX ind_tbUserAccount ON tbUserAccount(accountId) WHERE isUserMain = 1 and ckActive = 1
go

Create Table tbLaunch(
  Id int not null identity(1, 1) primary key,
  categoryId int not null FOREIGN KEY REFERENCES tbCategory(Id),
  accountId int not null FOREIGN KEY REFERENCES tbAccount(Id),
  launchType int not null,
  dsLaunch    varchar(100) not null,
  dtLaunch  Datetime  not null,
  price       money not null,
  Observation varchar(250),
  Tag         varchar(20),
  ckActive  bit not null default 1,
  dtCreate  Datetime  not null default getdate(),
)

