use [ITI-VSCode];

-- insert into Departments (DName, DLocation)
-- values ('PD', 'Menofia'), ('OS', 'Cairo'), ('SD', 'Alex'), ('Java', 'Smart'), ('Mern', 'Mansoura');

-- select * 
-- from Departments;

insert into Students (St_name, St_age, St_address, Dept_id)
values
('Ahmed', 20, 'Menofia', 1), 
('Mohamed', 21, 'Cairo', 2), 
('Ali', 22, 'Alex', 3), 
('Omar', 23, 'Smart', 4), 
('Mahmoud', 24, 'Mansoura', 5), 
('Hassan', 25, 'Menofia', 1), 
('Khaled', 26, 'Cairo', 2), 
('Amr', 27, 'Alex', 3), 
('Tamer', 28, 'Smart', 4), 
('Hany', 29, 'Mansoura', 5);

select * from Students;

SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Students';