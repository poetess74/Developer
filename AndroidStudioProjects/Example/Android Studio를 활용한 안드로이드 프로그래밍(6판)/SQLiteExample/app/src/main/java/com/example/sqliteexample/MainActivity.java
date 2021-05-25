package com.example.sqliteexample;

import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private SQLiteDatabase database;
    private static final String DB_NAME = "myDB.db";
    private static final String TABLE_NAME = "product";
    private LinearLayout container;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        init();
        setAction();
    }

    private void init() {
        container = findViewById(R.id.layout);
        database = openOrCreateDatabase(DB_NAME, MODE_PRIVATE, null);
    }

    private void setAction() {
        Cursor result = database.rawQuery("select * from " + TABLE_NAME + ";", null);
        textViewAdder(String.format("count : %d", result.getCount()), ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);

        result.moveToFirst();
        while(!result.isAfterLast()) {
            textViewAdder(String.format("%s | %d | %s | %s | %d", result.getString(0), result.getInt(1), result.getString(2), result.getString(3), result.getInt(4)), ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
            result.moveToNext();
        }
        result.close();
    }

    private void textViewAdder(String string, int layout_width, int layout_height) {
        TextView view = new TextView(this);
        view.setText(string);

        LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(layout_width, layout_height);
        view.setLayoutParams(layoutParams);

        container.addView(view);
    }
}