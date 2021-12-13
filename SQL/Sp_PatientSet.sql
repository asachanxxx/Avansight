ALTER PROCEDURE [cts].[Sp_PatientSet]
    @Patients AS [cts].[PatientTableType] READONLY
AS
BEGIN
    MERGE[cts].[Patient]  AS Target
    USING @Patients AS Source  
    ON (Target.PatientId = Source.PatientId)
   WHEN NOT MATCHED BY Target THEN
        INSERT (Age,Gender,StudyId,TreatmentId)  
        VALUES (Source.Age,Source.Gender,Source.StudyId,Source.TreatmentId);
END
GO

