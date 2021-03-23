package com.example.variousxmlattribute;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.TextUtils;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TextView[] textView = new TextView[3];

        textView[0] = (TextView) findViewById(R.id.textView1);
        textView[1] = (TextView) findViewById(R.id.textView2);
        textView[2] = (TextView) findViewById(R.id.textView3);

        textView[0].setText("좋은 아침");
        textView[0].setTextColor(Color.RED);

        textView[1].setTextSize(30);
        textView[1].setTypeface(Typeface.SANS_SERIF, Typeface.BOLD_ITALIC);

        textView[2].setText("ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ");
        textView[2].setSingleLine();
        textView[2].setEllipsize(TextUtils.TruncateAt.END);
    }
}