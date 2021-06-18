package com.example.clockwidget;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.TextView;

import java.text.DateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity {
    private TextView dateDisplay;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("시계 위젯");
        dateDisplay = findViewById(R.id.date);
        dateDisplay.setText(this.getDate());
    }

    private String getDate() {
        return DateFormat.getDateInstance(DateFormat.FULL).format(new Date());
    }
}