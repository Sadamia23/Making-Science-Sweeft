-- Task 6 

-- 1. Create Tables

CREATE TABLE Teacher (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    irstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Subject NVARCHAR(50) NOT NULL
);

CREATE TABLE Pupil (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Class NVARCHAR(20) NOT NULL
);

CREATE TABLE TeacherPupil (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    TeacherId INT NOT NULL,
    PupilId INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
    FOREIGN KEY (PupilId) REFERENCES Pupil(PupilId)
);

-- 2. Query

SELECT DISTINCT t.TeacherId, t.FirstName, t.LastName, t.Gender, t.Subject
FROM Teacher t
         INNER JOIN TeacherPupil tp ON t.TeacherId = tp.TeacherId
         INNER JOIN Pupil p ON tp.PupilId = p.PupilId
WHERE LOWER(p.FirstName) = LOWER('Giorgi');