ALTER PROCEDURE [cts].[TreatmentGroupImport]
    @TreatmentGroups AS [cts].[TreatmentGroupTableType] READONLY
AS
BEGIN
    MERGE [cts].[TreatmentGroup]  AS Target
    USING @TreatmentGroups AS Source  
    ON (Target.TreatmentId = Source.TreatmentId)
    WHEN NOT MATCHED BY Target THEN
        INSERT (TreatmentCode,TreatmentName,TreatmentColor)  
        VALUES (Source.TreatmentCode,Source.TreatmentName,Source.TreatmentColor);
END
GO

