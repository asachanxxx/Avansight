ALTER PROCEDURE [cts].[Sp_PatientGet]
    @StudyId int,
    @TreatmentCode varchar = NULL,
    @Age int = NULL,
    @Gender int = NULL
AS
BEGIN
  select @StudyId, @TreatmentCode , @Age,@Gender
  SELECT std.StudyId , tmg.TreatmentCode, pt.Age, pt.Gender from  [cts].[Patient] as pt
  INNER JOIN [cts].[TreatmentGroup] as tmg on pt.TreatmentId = tmg.TreatmentId 
  INNER JOIN [cts].[Study] as std on std.StudyId = pt.StudyId
  where 1 = 1 
  AND pt.StudyId = @StudyId
  AND (@TreatmentCode  IS NULL OR tmg.TreatmentCode  Like @TreatmentCode)
  AND (@Age  IS NULL OR pt.Age  Like @Age)
  AND (@Gender  IS NULL OR pt.Gender  Like @Gender)

END
GO

