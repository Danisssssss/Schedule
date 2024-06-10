// Кафедры
CREATE TABLE [dbo].[Cathedras] (
    [cathedra_id]   INT           IDENTITY (1, 1) NOT NULL,
    [cathedra_name] NVARCHAR (50) NOT NULL,
    [cathedra_code] NVARCHAR (20) NOT NULL,
    [faculty_id]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([cathedra_id] ASC),
    FOREIGN KEY ([faculty_id]) REFERENCES [dbo].[Faculties] ([faculty_id])
);

// Аудиторим
CREATE TABLE [dbo].[Classrooms] (
    [classroom_id]  INT           IDENTITY (1, 1) NOT NULL,
    [room_number]   NVARCHAR (50) NOT NULL,
    [room_specific] NVARCHAR (50) NULL,
    [room_capacity] INT           NULL,
    PRIMARY KEY CLUSTERED ([classroom_id] ASC)
);

// Предметы
CREATE TABLE [dbo].[Courses] (
    [course_id]   INT           IDENTITY (1, 1) NOT NULL,
    [course_name] NVARCHAR (50) NOT NULL,
    [section_Id]  INT           NULL,
    PRIMARY KEY CLUSTERED ([course_id] ASC),
    FOREIGN KEY ([section_Id]) REFERENCES [dbo].[Sections] ([section_Id])
);

// Дни
CREATE TABLE [dbo].[Days] (
    [day_id]   INT           IDENTITY (1, 1) NOT NULL,
    [day_name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([day_id] ASC)
);

// Факультеты
CREATE TABLE [dbo].[Faculties] (
    [faculty_id]   INT            IDENTITY (1, 1) NOT NULL,
    [faculty_name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([faculty_id] ASC)
);

// Группы
CREATE TABLE [dbo].[Groups] (
    [group_id]   INT           IDENTITY (1, 1) NOT NULL,
    [group_name] NVARCHAR (50) NOT NULL,
    [faculty_id] INT           NULL,
    PRIMARY KEY CLUSTERED ([group_id] ASC),
    FOREIGN KEY ([faculty_id]) REFERENCES [dbo].[Faculties] ([faculty_id])
);

// Секции (например: секция - математика, предмет - дискретная математика)
CREATE TABLE [dbo].[Sections] (
    [section_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [section_name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([section_Id] ASC)
);

// Преподаватели
CREATE TABLE [dbo].[Teachers] (
    [teacher_id]   INT           IDENTITY (1, 1) NOT NULL,
    [first_name]   NVARCHAR (50) NOT NULL,
    [teacher_post] NVARCHAR (50) NULL,
    [cathedra_id]  INT           NULL,
    PRIMARY KEY CLUSTERED ([teacher_id] ASC),
    FOREIGN KEY ([cathedra_id]) REFERENCES [dbo].[Cathedras] ([cathedra_id])
);

// Пара
CREATE TABLE [dbo].[TimeSlots] (
    [timeslot_id]   INT        IDENTITY (1, 1) NOT NULL,
    [start_time]    TIME (0)   NULL,
    [end_time]      TIME (0)   NOT NULL,
    [timeslot_name] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([timeslot_id] ASC)
);

// Расписание
CREATE TABLE [dbo].[Schedule] (
    [schedule_id]  INT IDENTITY (1, 1) NOT NULL,
    [course_id]    INT NULL,
    [teacher_id]   INT NULL,
    [group_id]     INT NULL,
    [classroom_id] INT NULL,
    [day_id]       INT NOT NULL,
    [timeslot_id]  INT NOT NULL,
    // Специфика занятия: лекция, лабораторная и т.д.
    [specific] NCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([schedule_id] ASC),
    FOREIGN KEY ([course_id]) REFERENCES [dbo].[Courses] ([course_id]),
    FOREIGN KEY ([teacher_id]) REFERENCES [dbo].[Teachers] ([teacher_id]),
    FOREIGN KEY ([group_id]) REFERENCES [dbo].[Groups] ([group_id]),
    FOREIGN KEY ([classroom_id]) REFERENCES [dbo].[Classrooms] ([classroom_id]),
    FOREIGN KEY ([day_id]) REFERENCES [dbo].[Days] ([day_id]),
    FOREIGN KEY ([timeslot_id]) REFERENCES [dbo].[TimeSlots] ([timeslot_id])
);

