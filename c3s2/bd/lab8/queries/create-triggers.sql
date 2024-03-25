CREATE OR REPLACE FUNCTION trg_insert_project()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO Project_Log (ProjectID, Action, Timestamp)
    VALUES (NEW.ProjectID, 'INSERT', NOW());
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_insert_project
AFTER INSERT ON Projects
FOR EACH ROW
EXECUTE FUNCTION trg_insert_project();

CREATE OR REPLACE FUNCTION trg_update_project()
RETURNS TRIGGER AS $$
BEGIN
    UPDATE Project_Info
    SET LastUpdated = NOW()
    WHERE ProjectID = OLD.ProjectID;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_update_project
AFTER UPDATE ON Projects
FOR EACH ROW
EXECUTE FUNCTION trg_update_project();

CREATE OR REPLACE FUNCTION trg_delete_project()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO Project_Archive (ProjectID, ProjectName, DeletedAt)
    VALUES (OLD.ProjectID, OLD.ProjectName, NOW());
    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_delete_project
AFTER DELETE ON Projects
FOR EACH ROW
EXECUTE FUNCTION trg_delete_project();


CREATE OR REPLACE FUNCTION trg_insert_employee()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO Employee_Log (EmployeeID, Action, Timestamp)
    VALUES (NEW.EmployeeID, 'INSERT', NOW());
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_insert_employee
AFTER INSERT ON Employees
FOR EACH ROW
EXECUTE FUNCTION trg_insert_employee();

CREATE OR REPLACE FUNCTION trg_update_employee()
RETURNS TRIGGER AS $$
BEGIN
    UPDATE Employee_Info
    SET LastUpdated = NOW()
    WHERE EmployeeID = OLD.EmployeeID;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_update_employee
AFTER UPDATE ON Employees
FOR EACH ROW
EXECUTE FUNCTION trg_update_employee();

CREATE OR REPLACE FUNCTION trg_delete_employee()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO Employee_Archive (EmployeeID, FirstName, LastName, DeletedAt)
    VALUES (OLD.EmployeeID, OLD.FirstName, OLD.LastName, NOW());
    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trig_delete_employee
AFTER DELETE ON Employees
FOR EACH ROW
EXECUTE FUNCTION trg_delete_employee();