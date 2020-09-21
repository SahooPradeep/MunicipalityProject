

/****** Object:  Table [dbo].[Municipalitydetails]    Script Date: 20-09-2020 21:48:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Municipalitydetails](
	[MunicipalityId] [int] IDENTITY(1,1) NOT NULL,
	[municipalityName] [varchar](100) NULL,
	[Date] [varchar](50) NULL,
	[Result] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Municipalitydetails] PRIMARY KEY CLUSTERED 
(
	[MunicipalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]
GO


