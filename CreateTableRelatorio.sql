SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relatorios](
	[Id] [uniqueidentifier] NOT NULL,
	[DataDoRelatorio] [datetime2](7) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[DataDaAplicacao] [datetime2](7) NOT NULL,
	[QuantidadeDeVacinados] [int] NOT NULL,
	[IdUsuario] [uniqueidentifier] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Relatorios] ADD  CONSTRAINT [PK_Relatorios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Relatorios_IdUsuario] ON [dbo].[Relatorios]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Relatorios]  WITH CHECK ADD  CONSTRAINT [FK_Relatorios_Usuarios_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Relatorios] CHECK CONSTRAINT [FK_Relatorios_Usuarios_IdUsuario]
GO
