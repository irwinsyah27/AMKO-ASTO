package com.sandinugraha.apps.amkoscanner.Model;

import com.google.gson.annotations.SerializedName;

/**
 * Created by sandinugraha on 26/01/18.
 */

public class History {
    @SerializedName("PID_HISTORI")
    private String PID_HISTORI;
    @SerializedName("HISTORY_DATE")
    private String HISTORY_DATE;
    @SerializedName("HISTORY_DATE_STR")
    private String HISTORY_DATE_STR;
    @SerializedName("ASSET_NUMBER")
    private String ASSET_NUMBER;
    @SerializedName("ASSET_NAME")
    private String ASSET_NAME;
    @SerializedName("LOCATION_CODE")
    private String LOCATION_CODE;
    @SerializedName("LOCATION_NAME")
    private String LOCATION_NAME;
    @SerializedName("COND_CODE")
    private String COND_CODE;
    @SerializedName("COND_NAME")
    private String COND_NAME;
    @SerializedName("PIC")
    private String PIC;
    @SerializedName("PIC_NAME")
    private String PIC_NAME;
    @SerializedName("REMARK")
    private String REMARK;

    public History(String PID_HISTORI, String HISTORY_DATE, String HISTORY_DATE_STR,
                   String ASSET_NUMBER, String ASSET_NAME, String LOCATION_CODE,
                   String LOCATION_NAME, String COND_CODE, String COND_NAME,
                   String PIC, String PIC_NAME, String REMARK) {
        this.PID_HISTORI = PID_HISTORI;
        this.HISTORY_DATE = HISTORY_DATE;
        this.HISTORY_DATE_STR = HISTORY_DATE_STR;
        this.ASSET_NUMBER = ASSET_NUMBER;
        this.ASSET_NAME = ASSET_NAME;
        this.LOCATION_CODE = LOCATION_CODE;
        this.LOCATION_NAME = LOCATION_NAME;
        this.COND_CODE = COND_CODE;
        this.COND_NAME = COND_NAME;
        this.PIC = PIC;
        this.PIC_NAME = PIC_NAME;
        this.REMARK = REMARK;
    }

    public String getPID_HISTORI() {
        return PID_HISTORI;
    }

    public void setPID_HISTORI(String PID_HISTORI) {
        this.PID_HISTORI = PID_HISTORI;
    }

    public String getHISTORY_DATE() {
        return HISTORY_DATE;
    }

    public void setHISTORY_DATE(String HISTORY_DATE) {
        this.HISTORY_DATE = HISTORY_DATE;
    }

    public String getHISTORY_DATE_STR() {
        return HISTORY_DATE_STR;
    }

    public void setHISTORY_DATE_STR(String HISTORY_DATE_STR) {
        this.HISTORY_DATE_STR = HISTORY_DATE_STR;
    }

    public String getASSET_NUMBER() {
        return ASSET_NUMBER;
    }

    public void setASSET_NUMBER(String ASSET_NUMBER) {
        this.ASSET_NUMBER = ASSET_NUMBER;
    }

    public String getASSET_NAME() {
        return ASSET_NAME;
    }

    public void setASSET_NAME(String ASSET_NAME) {
        this.ASSET_NAME = ASSET_NAME;
    }

    public String getLOCATION_CODE() {
        return LOCATION_CODE;
    }

    public void setLOCATION_CODE(String LOCATION_CODE) {
        this.LOCATION_CODE = LOCATION_CODE;
    }

    public String getLOCATION_NAME() {
        return LOCATION_NAME;
    }

    public void setLOCATION_NAME(String LOCATION_NAME) {
        this.LOCATION_NAME = LOCATION_NAME;
    }

    public String getCOND_CODE() {
        return COND_CODE;
    }

    public void setCOND_CODE(String COND_CODE) {
        this.COND_CODE = COND_CODE;
    }

    public String getCOND_NAME() {
        return COND_NAME;
    }

    public void setCOND_NAME(String COND_NAME) {
        this.COND_NAME = COND_NAME;
    }

    public String getPIC() {
        return PIC;
    }

    public void setPIC(String PIC) {
        this.PIC = PIC;
    }

    public String getPIC_NAME() {
        return PIC_NAME;
    }

    public void setPIC_NAME(String PIC_NAME) {
        this.PIC_NAME = PIC_NAME;
    }

    public String getREMARK() {
        return REMARK;
    }

    public void setREMARK(String REMARK) {
        this.REMARK = REMARK;
    }
}
