import React from 'react';
import {Box, Chip, FormControl, InputLabel, MenuItem, Select} from "@mui/material";

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
    PaperProps: {
        style: {
            maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
            width: 250,
        },
    },
};

type SelectType = {
    id: number,
    name: string,
}

const StyledSelect = <T extends SelectType, >({value, onChange, options}) => {
    return (
        <FormControl sx={{m: 1, width: 246}}>
            <InputLabel id="demo-multiple-name-label">Tags</InputLabel>
            <Select
                labelId="demo-multiple-name-label"
                id="demo-multiple-name"
                value={value}
                onChange={onChange}
                renderValue={(selected) => (
                    <Box sx={{display: 'flex', flexWrap: 'wrap', gap: 0.5}}>
                        {selected.map((value: T) =>
                            <Chip key={value.id} label={value.name}/>
                        )}
                    </Box>
                )}
                autoWidth
                label={"Tags"}
                multiple
                MenuProps={MenuProps}
            >
                {options?.map((tag: T) => (
                    <MenuItem
                        key={tag.name}
                        value={tag}
                    >
                        {tag.name}
                    </MenuItem>
                ))}
            </Select>
        </FormControl>
    );
};

export default StyledSelect;