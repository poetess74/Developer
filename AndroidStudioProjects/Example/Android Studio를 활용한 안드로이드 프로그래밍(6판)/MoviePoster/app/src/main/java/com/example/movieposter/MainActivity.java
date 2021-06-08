package com.example.movieposter;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridLayout;
import android.widget.GridView;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity {
    GridView gridView;
    MyGridAdapter gridAdapter;
    Integer[] posterID = new Integer[35];


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("그리드뷰 영화 포스터");
        init();
    }

    private void init() {
        gridView = findViewById(R.id.gridView1);
        posterID[0] = R.drawable.mov01;
        posterID[1] = R.drawable.mov02;
        posterID[2] = R.drawable.mov03;
        posterID[3] = R.drawable.mov04;
        posterID[4] = R.drawable.mov05;
        posterID[5] = R.drawable.mov06;
        posterID[6] = R.drawable.mov07;
        posterID[7] = R.drawable.mov08;
        posterID[8] = R.drawable.mov09;
        posterID[9] = R.drawable.mov10;
        posterID[10] = R.drawable.mov11;
        posterID[11] = R.drawable.mov12;
        posterID[12] = R.drawable.mov13;
        posterID[13] = R.drawable.mov14;
        posterID[14] = R.drawable.mov15;
        posterID[15] = R.drawable.mov16;
        posterID[16] = R.drawable.mov17;
        posterID[17] = R.drawable.mov18;
        posterID[18] = R.drawable.mov19;
        posterID[19] = R.drawable.mov20;
        posterID[20] = R.drawable.mov21;
        posterID[21] = R.drawable.mov22;
        posterID[22] = R.drawable.mov23;
        posterID[23] = R.drawable.mov24;
        posterID[24] = R.drawable.mov25;
        posterID[25] = R.drawable.mov26;
        posterID[26] = R.drawable.mov27;
        posterID[27] = R.drawable.mov28;
        posterID[28] = R.drawable.mov29;
        posterID[29] = R.drawable.mov30;
        posterID[30] = R.drawable.mov31;
        posterID[31] = R.drawable.mov32;
        posterID[32] = R.drawable.mov33;
        posterID[33] = R.drawable.mov34;
        posterID[34] = R.drawable.mov35;
        gridAdapter = new MyGridAdapter(getApplicationContext());
        gridView.setAdapter(gridAdapter);
    }

    private class MyGridAdapter extends BaseAdapter {
        Context context;

        public MyGridAdapter(Context context) {
            this.context = context;
        }

        @Override
        public int getCount() {
            return posterID.length;
        }

        @Override
        public Object getItem(int position) {
            return null;
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            ImageView view = new ImageView(context);
            view.setLayoutParams(new GridView.LayoutParams(200, 300));
            view.setScaleType(ImageView.ScaleType.FIT_CENTER);
            view.setPadding(5, 5, 5, 5);
            view.setImageResource(posterID[position]);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    View dialogView = View.inflate(MainActivity.this, R.layout.dialog, null);
                    AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.this);
                    ImageView ivPoster = dialogView.findViewById(R.id.ivPoster);
                    ivPoster.setImageResource(posterID[position]);
                    alert.setTitle("큰 포스터");
                    alert.setIcon(R.drawable.ic_launcher_foreground);
                    alert.setView(dialogView);
                    alert.setNegativeButton("닫기", null);
                    alert.show();
                }
            });
            return view;
        }
    }
}