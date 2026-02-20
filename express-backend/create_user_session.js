const sqlite3 = require("sqlite3").verbose();

const db = new sqlite3.Database("apps/app-sample/dev.sqlite3");

db.serialize(() => {
  db.run(
    `
    CREATE TABLE IF NOT EXISTS user_session (
      id INTEGER PRIMARY KEY,
      refresh_token TEXT
    );
  `,
    (err) => {
      if (err) {
        console.error("Error creating table:", err);
      } else {
        console.log("user_session table created or already exists");
      }
    },
  );
});

db.close();
