--USE [Multiplex.Tea]
USE [TeaTest]
--USE [TeaTesting]
GO

ALTER TABLE [dbo].[Genders] ADD  CONSTRAINT [PK_dbo.Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[CommunicationTypes] ADD  CONSTRAINT [PK_dbo.CommunicationTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserTitles] ADD  CONSTRAINT [PK_dbo.UserTitles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Applications] ADD  CONSTRAINT [PK_dbo.Applications] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserInformations] ADD  CONSTRAINT [PK_dbo.UserInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserInformations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserInformations_dbo.Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
GO

ALTER TABLE [dbo].[UserInformations] CHECK CONSTRAINT [FK_dbo.UserInformations_dbo.Genders_GenderId]
GO

ALTER TABLE [dbo].[UserInformations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserInformations_dbo.UserTitles_UserTitleId] FOREIGN KEY([UserTitleId])
REFERENCES [dbo].[UserTitles] ([Id])
GO

ALTER TABLE [dbo].[UserInformations] CHECK CONSTRAINT [FK_dbo.UserInformations_dbo.UserTitles_UserTitleId]


ALTER TABLE [dbo].[BusinessProfiles] ADD  CONSTRAINT [PK_dbo.BusinessProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[BusinessProfiles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfiles_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BusinessProfiles] CHECK CONSTRAINT [FK_dbo.BusinessProfiles_dbo.Categories_CategoryId]
GO

ALTER TABLE [dbo].[BusinessProfiles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfiles_dbo.UserInformations_UserInformationId] FOREIGN KEY([UserInformationId])
REFERENCES [dbo].[UserInformations] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfiles] CHECK CONSTRAINT [FK_dbo.BusinessProfiles_dbo.UserInformations_UserInformationId]
GO

ALTER TABLE [dbo].[BusinessProfileImages] ADD  CONSTRAINT [PK_dbo.BusinessProfileImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessProfileImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileImages_dbo.BusinessProfiles_BusinessProfileId] FOREIGN KEY([BusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileImages] CHECK CONSTRAINT [FK_dbo.BusinessProfileImages_dbo.BusinessProfiles_BusinessProfileId]
GO

ALTER TABLE [dbo].[BusinessProfileLikes] ADD  CONSTRAINT [PK_dbo.BusinessProfileLikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessProfileLikes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileLikes_dbo.BusinessProfiles_BusinessProfileId] FOREIGN KEY([BusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileLikes] CHECK CONSTRAINT [FK_dbo.BusinessProfileLikes_dbo.BusinessProfiles_BusinessProfileId]
GO

ALTER TABLE [dbo].[BusinessProfileLikes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileLikes_dbo.UserInformations_UserInformationId] FOREIGN KEY([UserInformationId])
REFERENCES [dbo].[UserInformations] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileLikes] CHECK CONSTRAINT [FK_dbo.BusinessProfileLikes_dbo.UserInformations_UserInformationId]
GO

ALTER TABLE [dbo].[BusinessProfileNeeds] ADD  CONSTRAINT [PK_dbo.BusinessProfileNeeds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessProfileNeeds]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.BusinessProfiles_BusinessProfileId] FOREIGN KEY([BusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileNeeds] CHECK CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.BusinessProfiles_BusinessProfileId]
GO

ALTER TABLE [dbo].[BusinessProfileNeeds]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.BusinessProfiles_FulfillerBusinessProfileId] FOREIGN KEY([FulfillerBusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileNeeds] CHECK CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.BusinessProfiles_FulfillerBusinessProfileId]
GO

ALTER TABLE [dbo].[BusinessProfileNeeds]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileNeeds] CHECK CONSTRAINT [FK_dbo.BusinessProfileNeeds_dbo.Categories_CategoryId]
GO

ALTER TABLE [dbo].[BusinessProfileRecommendations] ADD  CONSTRAINT [PK_dbo.BusinessProfileRecommendations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessProfileRecommendations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileRecommendations_dbo.BusinessProfiles_BusinessProfileId] FOREIGN KEY([BusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileRecommendations] CHECK CONSTRAINT [FK_dbo.BusinessProfileRecommendations_dbo.BusinessProfiles_BusinessProfileId]
GO

ALTER TABLE [dbo].[BusinessProfileRecommendations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BusinessProfileRecommendations_dbo.UserInformations_UserInformationId] FOREIGN KEY([UserInformationId])
REFERENCES [dbo].[UserInformations] ([Id])
GO

ALTER TABLE [dbo].[BusinessProfileRecommendations] CHECK CONSTRAINT [FK_dbo.BusinessProfileRecommendations_dbo.UserInformations_UserInformationId]
GO

ALTER TABLE [dbo].[CommentConversations] ADD  CONSTRAINT [PK_dbo.CommentConversations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CommentConversations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CommentConversations_dbo.BusinessProfileRecommendations_BusinessProfileRecommendationId] FOREIGN KEY([BusinessProfileRecommendationId])
REFERENCES [dbo].[BusinessProfileRecommendations] ([Id])
GO

ALTER TABLE [dbo].[CommentConversations] CHECK CONSTRAINT [FK_dbo.CommentConversations_dbo.BusinessProfileRecommendations_BusinessProfileRecommendationId]
GO

ALTER TABLE [dbo].[CommentConversations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CommentConversations_dbo.CommentConversations_CommentConversationResponseId] FOREIGN KEY([CommentConversationResponseId])
REFERENCES [dbo].[CommentConversations] ([Id])
GO

ALTER TABLE [dbo].[CommentConversations] CHECK CONSTRAINT [FK_dbo.CommentConversations_dbo.CommentConversations_CommentConversationResponseId]
GO

ALTER TABLE [dbo].[CommentConversations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CommentConversations_dbo.UserInformations_UserInformationId] FOREIGN KEY([UserInformationId])
REFERENCES [dbo].[UserInformations] ([Id])
GO

ALTER TABLE [dbo].[CommentConversations] CHECK CONSTRAINT [FK_dbo.CommentConversations_dbo.UserInformations_UserInformationId]
GO

ALTER TABLE [dbo].[Communications] ADD  CONSTRAINT [PK_dbo.Communications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Communications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Communications_dbo.BusinessProfiles_BusinessProfileId] FOREIGN KEY([BusinessProfileId])
REFERENCES [dbo].[BusinessProfiles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Communications] CHECK CONSTRAINT [FK_dbo.Communications_dbo.BusinessProfiles_BusinessProfileId]
GO

ALTER TABLE [dbo].[Communications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Communications_dbo.CommunicationTypes_CommunicationTypeId] FOREIGN KEY([CommunicationTypeId])
REFERENCES [dbo].[CommunicationTypes] ([Id])
GO

ALTER TABLE [dbo].[Communications] CHECK CONSTRAINT [FK_dbo.Communications_dbo.CommunicationTypes_CommunicationTypeId]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserApplication]
GO

ALTER TABLE [dbo].[Memberships] ADD  CONSTRAINT [PK_dbo.Memberships] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO

ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipApplication]
GO

ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipUser]
GO

ALTER TABLE [dbo].[Profiles] ADD  CONSTRAINT [PK_dbo.Profiles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [UserProfile]
GO

ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO

ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleApplication]
GO

DELETE FROM UsersInRoles WHERE UserId IN ( SELECT UserId FROM UsersInRoles WHERE UserId NOT IN (SELECT UserId FROM Users))

ALTER TABLE [dbo].[UsersInRoles] ADD  CONSTRAINT [PK_dbo.UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleRole1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO

ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleRole1]
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleUser1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleUser1]
GO



