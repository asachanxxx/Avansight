ALTER TRIGGER  Trigger_ForPatient
ON [cts].[Patient]
FOR INSERT  
AS  
begin
    SELECT PatientId
    FROM INSERTED
end  
