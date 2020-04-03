SET IDENTITY_INSERT [dbo].[CandidateVote] ON
INSERT INTO [dbo].[CandidateVote] ([Id], [Candidate], [Party], [NumberOfVotes]) VALUES (1, N'Garry Smith', N'National People''s Front', 1500000)
INSERT INTO [dbo].[CandidateVote] ([Id], [Candidate], [Party], [NumberOfVotes]) VALUES (2, N'Frank Miller', N'National Liberation Party ', 2000456)
INSERT INTO [dbo].[CandidateVote] ([Id], [Candidate], [Party], [NumberOfVotes]) VALUES (3, N'Joe Harris', N'Democratic ', 3200000)
SET IDENTITY_INSERT [dbo].[CandidateVote] OFF
