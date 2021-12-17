SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [cts].[Sp_PatientGet]
    @StudyId int,
    @TreatmentCode varchar = NULL,
    @MinAge int = NULL,
    @MaxAge int = NULL,
    @Gender int = NULL
AS
BEGIN
  SELECT std.StudyId , tmg.TreatmentCode, pt.Age, pt.Gender from  [cts].[Patient] as pt
  INNER JOIN [cts].[TreatmentGroup] as tmg on pt.TreatmentId = tmg.TreatmentId 
  INNER JOIN [cts].[Study] as std on std.StudyId = pt.StudyId
  where 1 = 1 
  AND pt.StudyId = @StudyId
  AND (@TreatmentCode  IS NULL OR tmg.TreatmentCode  Like @TreatmentCode)
  AND (@MinAge  IS NULL OR @MinAge  IS NULL OR pt.Age  BETWEEN @MinAge and @MaxAge)
  AND (@Gender  IS NULL OR pt.Gender  Like @Gender)

END
GO
