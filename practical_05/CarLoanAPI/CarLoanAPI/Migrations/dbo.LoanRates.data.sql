SET IDENTITY_INSERT [dbo].[LoanRates] ON
INSERT INTO [dbo].[LoanRates] ([LoanRateID], [Term], [Rate]) VALUES (1, 3, CAST(3.50 AS Decimal(4, 2)))
INSERT INTO [dbo].[LoanRates] ([LoanRateID], [Term], [Rate]) VALUES (2, 5, CAST(4.00 AS Decimal(4, 2)))
INSERT INTO [dbo].[LoanRates] ([LoanRateID], [Term], [Rate]) VALUES (3, 7, CAST(4.50 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[LoanRates] OFF
