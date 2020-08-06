SELECT * FROM users u
    JOIN Pothole p on u.user_id = p.user_id

-- UPDATE Pothole 
--     SET user_id = 1
--     WHERE Id = 1

SELECT * from Pothole

-- DELETE FROM Pothole 


-- Pothole Data

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1400 W 6th St Cleveland OH 44113', '07/23/2020', 'Pothole on the street outside Taza - a Lebanese Grill' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1360 W Mall Dr Cleveland OH 44114', '06/25/2020', 'Large pothole on the north side of the street near the Cleveland Marriot hotel' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1455 E 6th St Cleveland OH 44114', '05/14/2020', 'Small but annoying pothole near the Federal Reeserve Bank' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('300 Lakeside Ave E Cleveland, OH 44113', '04/16/2020', 'Enourmous pothole in front of the convention center' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1200 Ontario St Cleveland OH 44113', '07/23/2020', 'You wont beleive the size of this hole in the road until you see it. Located right outside the Courthouse' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1301 E 9th St, Cleveland, OH 44114', '02/23/2020', 'This is the third time I have reported this pothole. It is unavoidable and I hit it everyday' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1701 E 12th St Cleveland OH 44114', '03/16/2020', 'This is the worst pothole in cleveland I gaurantee it. I have hit it with my car 100 times' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1470 Lakeside Ave E, Cleveland, OH 44114', '04/15/2020', 'I am pretty sure this pothole is so deep I can see lakewater at the bottom' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1261 Superior Ave, Cleveland, OH 44114', '07/19/2020', 'This pothole is on the south side of the street near Masthead Brewry' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('1900 Superior Ave, Cleveland, OH 44114', '07/19/2020', 'This pothole is right outside the tower press building' )

INSERT INTO Pothole ([Location], DateAdded, [Description])
    VALUES ('601 Erieside Ave, Cleveland, OH 441144', '07/19/2020', 'Seeing that this is actually a bridk road. I think it may just be missing bricks but I think it still counts' )

UPDATE Pothole
    SET Status = 3 
    WHERE Id = 19

    
