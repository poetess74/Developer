package com.example.groupdb;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private myDBHelper myDBHelper;
    private EditText name, number;
    private TextView nameResult, numberResult;
    private Button init, insert, select, update, delete;
    private SQLiteDatabase sqlDB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        init();
        setAction();
    }

    private void init() {
        name = findViewById(R.id.editName);
        number = findViewById(R.id.editNumber);
        nameResult = findViewById(R.id.nameResult);
        numberResult = findViewById(R.id.numberResult);

        init = findViewById(R.id.btnInit);
        insert = findViewById(R.id.btnInsert);
        update = findViewById(R.id.btnUpdate);
        delete = findViewById(R.id.btnDelete);
        select = findViewById(R.id.btnSelect);

        myDBHelper = new myDBHelper(getApplicationContext());
    }

    private void setAction() {
        init.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sqlDB = myDBHelper.getWritableDatabase();
                myDBHelper.onUpgrade(sqlDB, 1, 2);
                sqlDB.close();
                Toast.makeText(getApplicationContext(), "초기화됨", Toast.LENGTH_SHORT).show();
                select.callOnClick();
                name.setText(null);
                number.setText(null);
            }
        });

        insert.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sqlDB = myDBHelper.getWritableDatabase();
                sqlDB.execSQL("INSERT INTO groupDB VALUES (" +
                        "'" + name.getText().toString() + "', " +
                        "'" + number.getText().toString() + "'" +
                        ");");
                sqlDB.close();
                Toast.makeText(getApplicationContext(), "입력됨", Toast.LENGTH_SHORT).show();
                select.callOnClick();
            }
        });

        update.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sqlDB = myDBHelper.getWritableDatabase();
                sqlDB.execSQL("UPDATE groupDB SET gNumber = '" + number.getText().toString() + "' WHERE gName = '" + name.getText().toString() + "';");
                sqlDB.close();
                Toast.makeText(getApplicationContext(), "변경됨", Toast.LENGTH_SHORT).show();
                select.callOnClick();
            }
        });

        delete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sqlDB = myDBHelper.getWritableDatabase();
                sqlDB.execSQL("DELETE FROM groupDB WHERE gName = '" + name.getText().toString() + "';");
                sqlDB.close();
                Toast.makeText(getApplicationContext(), "삭제됨", Toast.LENGTH_SHORT).show();
                select.callOnClick();
            }
        });

        select.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sqlDB = myDBHelper.getReadableDatabase();
                Cursor cursor;
                cursor = sqlDB.rawQuery("SELECT * FROM groupDB;", null);

                String strName = "그룹 이름" + "\n" + "----------" + "\n";
                String strNumber = "인원" + "\n" + "----------" + "\n";

                while(cursor.moveToNext()) {
                    strName += cursor.getString(0) + "\n";
                    strNumber += cursor.getString(1) + "\n";
                }

                nameResult.setText(strName);
                numberResult.setText(strNumber);

                cursor.close();
                sqlDB.close();
                Toast.makeText(getApplicationContext(), "조회됨", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private class myDBHelper extends SQLiteOpenHelper {
        public myDBHelper(Context context) {
            super(context, "groupDB", null, 1);
        }

        @Override
        public void onCreate(SQLiteDatabase sqLiteDatabase) {
            sqLiteDatabase.execSQL("CREATE TABLE groupDB ( gName CHAR(20) PRIMARY KEY, gNumber INTEGER);");
        }

        @Override
        public void onUpgrade(SQLiteDatabase sqLiteDatabase, int oldVersion, int newVersion) {
            sqLiteDatabase.execSQL("DROP TABLE IF EXISTS groupDB");
            onCreate(sqLiteDatabase);
        }
    }
}