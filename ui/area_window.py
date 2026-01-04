from ui.crud_base import CrudBaseWindow


class AreaWindow(CrudBaseWindow):
    def __init__(self, dao, translations):
        fields = [
            {
                "name": "area",
                "label_key": "col_area",
                "label_default": "Area",
                "placeholder_key": "col_area",
                "placeholder_default": "Area",
            },
            {
                "name": "area_desc",
                "label_key": "col_area_desc",
                "label_default": "Desc",
                "placeholder_key": "col_area_desc",
                "placeholder_default": "Description",
            },
        ]
        super().__init__(
            dao,
            translations,
            title_key="area_window_title",
            title_default="區域維護",
            size=(700, 480),
            headers=["area", "area_desc", "active"],
            header_label_keys=[
                ("col_area", "area"),
                ("col_area_desc", "area_desc"),
                ("col_active", "active"),
            ],
            fields=fields,
            checkbox_field={"name": "active", "label_key": "active", "label_default": "Active"},
            key_field="area",
            list_method=dao.list_all_areas,
            create_method=dao.create_area,
            update_method=dao.update_area,
            delete_method=dao.delete_area,
            required_messages={
                "create": ("msg_required_area", "Area is required"),
                "update": ("msg_required_area", "Area is required"),
                "delete": ("msg_required_area", "Area is required"),
            },
            center_columns=[2],
        )
