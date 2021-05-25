package com.example.dbmethodtest;

import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private SQLiteDatabase database;
    private TextView selectRow;

    private static final String DB_NAME = "DBTest.db";
    private static final String TABLE_NAME = "people";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        init();
        setAction();
    }

    private void init() {
        selectRow = findViewById(R.id.selectRow);
    }

    private void setAction() {
        database = openOrCreateDatabase(DB_NAME, MODE_PRIVATE, null);
        database.execSQL("CREATE TABLE IF NOT EXISTS " + TABLE_NAME + "(" +
                "_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "name TEXT, " +
                "age INTEGER" +
                ");");
        database.execSQL("INSERT INTO " + TABLE_NAME +
                " (name, age) VALUES (" +
                "'" + "kim" + "', " +
                20 +
                ");");

        Cursor result = database.rawQuery("SELECT * FROM " + TABLE_NAME + ";", null);
        Log.println(Log.DEBUG, "SQLite", Integer.toString(result.getCount()));

        result.moveToFirst();
        while (!result.isAfterLast()) {
            String name = result.getString(1);
            Log.println(Log.DEBUG, "SQLite", name);
            selectRow.append("\n");
            selectRow.append(name);
            result.moveToNext();
        }
        result.close();
    }
}