package com.sandinugraha.apps.amkoscanner.Adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.sandinugraha.apps.amkoscanner.Model.History;
import com.sandinugraha.apps.amkoscanner.R;

import java.util.List;

/**
 * Created by sandinugraha on 28/01/18.
 */

public class HistoriesAdapter extends RecyclerView.Adapter<HistoriesAdapter.HistoryViewHolder> {

    private List<History> histories;
    private int rowLayout;
    private Context context;

    public static class HistoryViewHolder extends RecyclerView.ViewHolder {
        LinearLayout historiesLayout;
        private TextView historyDate;
        private TextView assetName;
        private TextView locationName;
        private TextView condName;
        private TextView picName;
        private TextView remark;

        public HistoryViewHolder(View v) {
            super(v);

            this.historiesLayout = (LinearLayout) v.findViewById(R.id.history_layout);
            this.historyDate = (TextView) v.findViewById(R.id.tx_history_date);
            this.assetName = (TextView) v.findViewById(R.id.tx_history_asset_name);
            this.locationName = (TextView) v.findViewById(R.id.tx_history_location_name);
            this.condName =  (TextView) v.findViewById(R.id.tx_history_cond_name);
            this.picName = (TextView) v.findViewById(R.id.tx_history_pic_name);
            this.remark = (TextView) v.findViewById(R.id.tx_history_remark);
        }

        public LinearLayout getHistoriesLayout() {
            return historiesLayout;
        }

        public TextView getHistoryDate() {
            return historyDate;
        }

        public TextView getAssetName() {
            return assetName;
        }

        public TextView getLocationName() {
            return locationName;
        }

        public TextView getCondName() {
            return condName;
        }

        public TextView getPicName() {
            return picName;
        }

        public TextView getRemark() {
            return remark;
        }
    }

    public HistoriesAdapter(List<History> histories,int rowLayout,Context context) {
        this.histories = histories;
        this.rowLayout = rowLayout;
        this.context = context;
    }

    @Override
    public HistoriesAdapter.HistoryViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(rowLayout,parent,false);

        return new HistoryViewHolder(view);
    }

    @Override
    public void onBindViewHolder(HistoryViewHolder holder, final int position) {
        holder.getHistoryDate().setText(histories.get(position).getHISTORY_DATE_STR());
        holder.getAssetName().setText(histories.get(position).getASSET_NAME());
        holder.getLocationName().setText(histories.get(position).getLOCATION_NAME());
        holder.getCondName().setText(histories.get(position).getCOND_NAME());
        holder.getPicName().setText(histories.get(position).getPIC_NAME());
        holder.getRemark().setText(histories.get(position).getREMARK());
    }

    @Override
    public int getItemCount() {
        return histories.size();
    }

}
