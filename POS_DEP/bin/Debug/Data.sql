if not exists (select * from CodeType where [Code] = 'UN')
INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (1, N'Unit', N'UN')
if not exists (select * from CodeType where [Code] = 'GR')
INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (2, N'Group', N'GR')
if not exists (select * from CodeType where [Code] = 'PARTY')
INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (3, N'Party', N'PARTY')
if not exists (select * from CodeType where [Code] = 'FM')
INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (4, N'Firm', N'FM')
if not exists (select * from CodeType where [Code] = 'TB')
INSERT [dbo].[CodeType] ([ID], [Name], [Code]) VALUES (5, N'Table', N'TB')

if not exists (select * from [UserType] where [UserTypeCode] = 10)
INSERT [dbo].[UserType] ([UserTypeCode], [UserTypeName]) VALUES (10, N'Super User')
if not exists (select * from [UserType] where [UserTypeCode] = 20)
INSERT [dbo].[UserType] ([UserTypeCode], [UserTypeName]) VALUES (20, N'Administrator')
if not exists (select * from [UserType] where [UserTypeCode] = 30)
INSERT [dbo].[UserType] ([UserTypeCode], [UserTypeName]) VALUES (30, N'User')
 
if not exists (select * from [UserLogin])
begin 
	SET IDENTITY_INSERT [dbo].[UserLogin] ON
	INSERT [dbo].[UserLogin] ([ID], [LoginID], [Password], [DisplayName], [UserType]) VALUES (1, N'SU', N'SU123456', N'TIS', 10)
	INSERT [dbo].[UserLogin] ([ID], [LoginID], [Password], [DisplayName], [UserType]) VALUES (2, N'admin', N'456789', N'TIS', 20)
	SET IDENTITY_INSERT [dbo].[UserLogin] OFF
end 