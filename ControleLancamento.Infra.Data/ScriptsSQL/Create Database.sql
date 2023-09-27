Create database dbControleLancamento;
go
Use dbControleLancamento;
GO

Create Table tbCategory(
  Id int not null identity(1, 1) primary key,
  nmCategory   varchar(100) not null,
  Color        varchar(7),
  Icon         varchar(20),
  ckActive     bit not null default 1,
  dtCreate     Datetime  not null default getdate()
)
go

Create Table tbCategoryType(
  Id int not null identity(1, 1) primary key,
  nmCategoryType   varchar(100) not null,
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
CREATE UNIQUE INDEX ind_tbUserAccount ON tbUserAccount(accountId) WHERE isUserMain = 1
go

Create Table tbLaunch(
  Id int not null identity(1, 1) primary key,
  launchType int not null ,
  categoryId int not null FOREIGN KEY REFERENCES tbCategory(Id),
  price       money not null,
  Observation varchar(100),
  Tag         varchar(20),
  ckActive  bit not null default 1,
  dtCreate  Datetime  not null default getdate(),
)

