USE master;
GO

-- Delete the EmployeeDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='MusicTrivia')
DROP DATABASE MusicTrivia;
GO

-- Create a new EmployeeDB Database
CREATE DATABASE MusicTrivia;
GO

-- Switch to the EmployeeDB Database
USE MusicTrivia
GO

BEGIN TRANSACTION;

CREATE TABLE questions (

    question_id integer identity(1,1) NOT NULL,
    [text] varchar(100) NOT NULL,

    CONSTRAINT pk_question_question_id PRIMARY KEY (question_id),
);

CREATE TABLE answers (

    answer_id integer identity (1,1)  NOT NULL,
    question_id integer not null,
	[value] varchar(100) not null,
	isCorrect bit not null

	
	CONSTRAINT fk_answers_questions FOREIGN KEY (question_id) REFERENCES questions(question_id)
);

SET IDENTITY_INSERT questions ON;

INSERT INTO questions (question_id, text) VALUES (1, 'What year was the album Hotel California released?');
INSERT INTO questions (question_id, text) VALUES (2, 'Who is Led Zeppelin''s guitar player?');
INSERT INTO questions (question_id, text) VALUES (3, 'Which band wrote the song Takin'' care of business?')
INSERT INTO questions (question_id, text) VALUES (4, 'What band has both Stevie Nicks and Christine McVie?')

SET IDENTITY_INSERT questions OFF;

SET IDENTITY_INSERT answers ON;

INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (1, 1 , '1972' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (2, 1 , '1970' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (3, 1 , '1977' , 1)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (4, 1 , '1969' , 0)

INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (1, 2, 'Jimmy Page', 1)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (2, 2, 'Robert Plant', 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (3, 2, 'Angus Young', 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (4, 2, 'Neil Young' , 0)

INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (1, 3, 'Pink Floyd' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (2, 3, 'The Cars' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (3, 3, 'Aerosmith' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (4, 3, 'Bachman-Turner Overdrive' , 1)

INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (1, 4 , 'Heart' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (2, 4 , 'Fleetwood Mac' , 1)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (3, 4 , 'Sonny and Cher' , 0)
INSERT INTO answers (answer_id, question_id, value, isCorrect) Values (4, 4 , 'The Ronettes' , 0)

SET IDENTITY_INSERT answers OFF;

COMMIT TRANSACTION;

select * from questions
select * from answers