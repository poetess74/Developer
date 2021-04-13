package com.example.scheduledate;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.os.Bundle;
import android.os.SystemClock;
import android.view.View;
import android.widget.Button;
import android.widget.CalendarView;
import android.widget.Chronometer;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.TimePicker;

enum DateIndex {
    YEAR(0), MONTH(1), DAY(2), HOUR(3), MIN(4);

    private final int value;

    private DateIndex(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}

enum SelectDateIndex {
    SEL_YER(0), SEL_MON(1), SEL_DAY(2);

    private final int value;

    private SelectDateIndex(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}

public class MainActivity extends AppCompatActivity {
    Chronometer chronometer;
    Button start, end;
    RadioButton Cal, Time;
    CalendarView calendarView;
    TimePicker picker;
    TextView[] textViews;
    int[] Dates;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("시간 예약");

        textViews = new TextView[5];
        Dates = new int[3];

        start = findViewById(R.id.btnStart);
        end = findViewById(R.id.btnEnd);

        chronometer = findViewById(R.id.chronometer1);

        Cal = findViewById(R.id.rdoCal);
        Time = findViewById(R.id.rdoTime);

        picker = findViewById(R.id.timePicker1);
        calendarView = findViewById(R.id.calendarView1);

        textViews[DateIndex.YEAR.getValue()] = findViewById(R.id.tvYear);
        textViews[DateIndex.MONTH.getValue()] = findViewById(R.id.tvMonth);
        textViews[DateIndex.DAY.getValue()] = findViewById(R.id.tvDay);
        textViews[DateIndex.HOUR.getValue()] = findViewById(R.id.tvHour);
        textViews[DateIndex.MIN.getValue()] = findViewById(R.id.tvMinute);

        picker.setVisibility(View.INVISIBLE);
        calendarView.setVisibility(View.INVISIBLE);

        Cal.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                picker.setVisibility(View.INVISIBLE);
                calendarView.setVisibility(View.VISIBLE);
            }
        });
        Time.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                picker.setVisibility(View.VISIBLE);
                calendarView.setVisibility(View.INVISIBLE);
            }
        });

        start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                chronometer.setBase(SystemClock.elapsedRealtime());
                chronometer.start();
                chronometer.setTextColor(Color.RED);
            }
        });
        end.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                chronometer.stop();
                chronometer.setTextColor(Color.BLUE);

                textViews[DateIndex.YEAR.getValue()].setText(Integer.toString(Dates[SelectDateIndex.SEL_YER.getValue()]));
                textViews[DateIndex.MONTH.getValue()].setText(Integer.toString(Dates[SelectDateIndex.SEL_MON.getValue()]));
                textViews[DateIndex.DAY.getValue()].setText(Integer.toString(Dates[SelectDateIndex.SEL_DAY.getValue()]));
                textViews[DateIndex.HOUR.getValue()].setText(Integer.toString(picker.getHour()));
                textViews[DateIndex.MIN.getValue()].setText(Integer.toString(picker.getMinute()));
            }
        });

        calendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                Dates[SelectDateIndex.SEL_YER.getValue()] = year;
                Dates[SelectDateIndex.SEL_MON.getValue()] = month + 1;
                Dates[SelectDateIndex.SEL_DAY.getValue()] = dayOfMonth;
            }
        });
    }
}